using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    internal class Calculator
    {
        public List<double> Numbers { get; private set; }

        public Dictionary<string, Func<double, double>> Operations { get; }
        public Dictionary<string, Func<double, double, double>> OperationsWithArg { get; }
        public Dictionary<string, Func<List<double>, List<double>>> OperationsReduce { get; }

        public List<Func<List<double>, List<double>>> OperationHistory { get; private set; }
        public List<Tuple<List<double>, int>> DataHistory { get; private set; }

        public List<Tuple<List<double>, int>> AppendedHistory { get; private set; }

        public bool IsTravelling { get; private set; } = false;
        private List<List<double>> travelBuffer_ = new List<List<double>>();
        private int startingTime_;
        private int currentTime_;
        public int CurrentTime { get { return currentTime_; } private set { currentTime_ = value; } }

        public Calculator()
        {
            Numbers = new List<double>();

            /**
             *  Словарь, позволяющий получать соответствующую функцию. Здесь функции не требуют
             *  двух аргументов, например функции sqr достаточно одного (arg * arg).
             */ 
            Operations = new Dictionary<string, Func<double, double>>()
            {
                {"sqr",  SqrSolo},
                {"sqrt", SqrtSolo},
                {"fact", FactSolo},
            };

            /**
             *  Аналагично Operations, только функции уже принимают 2 аргумента.
             */ 
            OperationsWithArg = new Dictionary<string, Func<double, double, double>>()
            {
                {"+",     AddValue},
                {"-",     ExtractValue},
                {"*",     MultiplyValue},
                {"/",     DivideValue},
                {"pow",   PowValue},
                {"sqrtn", SqrtnValue},
                {"log",   LogValue},
            };

            /**
             *  Особые функции, отображающие список чисел в одно число. Для удобства это число обернутно также в список
             */
            OperationsReduce = new Dictionary<string, Func<List<double>, List<double>>>()
            {
                {"median",    MedianList},
                {"deviation", DeviationList},
            };

            /**
             *  История операций. После каждого Append'a или Apply'a проивходит некое преобразование из одногш списка
             *  в другой. Это преобразование можно задать как композицию функций. Например, если в набрана формула + 2; * 2; log 3;
             *  то функция, которая будет добавлена в этот список, будет принимать список и для каждого элемена в нем сначала применять +2, затем *2
             *  и т.д. 
             */ 
            OperationHistory = new List<Func<List<double>, List<double>>>();

            /**
             *  История списков, которые были сохранены с помощью команды Save. Добавляются сюда списки опционально, т.к. при каждом добавлении
             *  растет потребление памяти программой, однако умеренное использование команды Save может улучшить перфоманс. Можно заметить, что
             *  это лист из пар соотвествующих списков и int'a. Int - кол-во элементов в OperationHistory на момент Save или по-другому 
             *  Calculator.CurrentTime.
             */ 
            DataHistory = new List<Tuple<List<double>, int>>() { new Tuple<List<double>, int>(new List<double>(), -1) };

            /**
             *  Хранит списки новых, добавленных элементов и, соотвественно, время. Используется для восставновления предыдущих состояний калькулятора
             */ 
            AppendedHistory = new List<Tuple<List<double>, int>>();
        }

        public bool IsOperation(string str)
        {
            return Operations.Keys.Contains(str) ||
                   OperationsWithArg.Keys.Contains(str) ||
                   OperationsReduce.Keys.Contains(str);
        }

        public bool IsArgumentNeededForOperation(string str)
        {
            return OperationsWithArg.Keys.Contains(str);
        }

        public void AppendNumber(double number)
        {
            Numbers.Add(number);
            if (AppendedHistory.Count == 0 || AppendedHistory[AppendedHistory.Count - 1].Item2 != OperationHistory.Count)
            {
                var newList = new List<double>() { number, };
                AppendedHistory.Add(new Tuple<List<double>, int>(newList, OperationHistory.Count));
            }
            else
            {
                var lastTuple = AppendedHistory[AppendedHistory.Count - 1];
                lastTuple.Item1.Add(number);
            }
        }
        
        public void ClearNumbers()
        {
            Numbers.Clear();
            OperationHistory.Add(list => { list.Clear(); return list; });
        }

        public void AppendToOperationHistoryAppend()
        {
            Func<List<double>, List<double>> operation = list =>
            {
                int index = 0;
                for (int it = 0; it < AppendedHistory.Count; it++)
                {
                    if (AppendedHistory[it].Item2 == CurrentTime)
                    {
                        index = it;
                        break;
                    }
                }

                foreach (var el in AppendedHistory[index].Item1) //count - 1 was before
                {
                    list.Add(el);
                }
                return list;
            };

            AppendToOperationHistory(operation);
        }


        //Следующие 4 функции работают с историей состояний калькулятора.

        //Основные идеи реализации.
        //Будем доставать ближайший Save, который сделал пользователь (если такого нет вообще, то идем с самого низа - пустого списка)
        //Далее заводим буфер из списков длиной от Save до текущей позиции (для быстроты Undo и Repeat).
        //Остается теперь правильно определять индексы в буферах и обновлять их восле выходы за их пределы.
        //У нас есть OperationHistory, соотвественно, проблем с заполнением буфера не будет - будет брать начальный список с Save'a и применять 
        //к нему последоватльное сохраненные функции. Так мы будем восстанавливать историю.


        /**
         *  Инициализация. Запускается после первого нажатия Undo. Создаем первый буфер от ближайшего Save'a до текущей позиции, т.е.
         *  в данном случае CurrentTime.
         */
        public void StartTraveling()
        {
            IsTravelling = true;
            CurrentTime = OperationHistory.Count - 1;
            startingTime_ = DataHistory[DataHistory.Count - 1].Item2;
            var start_list = new List<double>(DataHistory[DataHistory.Count - 1].Item1);
            travelBuffer_.Add(start_list);
            List<double> cur_list = start_list;
            CurrentTime = startingTime_ + 1;
            for (var it = startingTime_ + 1; it < OperationHistory.Count - 1; it++)
            {
                cur_list = OperationHistory[it](new List<double>(cur_list));
                CurrentTime++;
                travelBuffer_.Add(cur_list);
            }

            CurrentTime = OperationHistory.Count - 1;
        }


        /**
         *  Шаг назад по времени
         */
        public List<double> GoBackInTime()
        {
            var newTime = CurrentTime - 1;

            if (newTime < startingTime_)
            {
                travelBuffer_ = new List<List<double>>();
                int res_it = -1;
                for (var it = DataHistory.Count - 1; it > -1; it--)
                {
                    if (DataHistory[it].Item2 <= newTime)
                    {
                        res_it = it;
                        break;
                    }
                }

                startingTime_ = DataHistory[res_it].Item2;
                var start_list = new List<double>(DataHistory[res_it].Item1);
                travelBuffer_.Add(start_list);
                List<double> cur_list = start_list;
                CurrentTime = startingTime_ + 1;
                for (var it = startingTime_ + 1; it < newTime + 1; it++)
                {
                    cur_list = OperationHistory[it](new List<double>(cur_list));
                    CurrentTime++;
                    travelBuffer_.Add(cur_list);
                }
            }

            CurrentTime = newTime;
            var index = newTime - startingTime_;
            return travelBuffer_[index];
        }

        public void StopTraveling()
        {
            IsTravelling = false;
            travelBuffer_ = new List<List<double>>();
            CurrentTime = OperationHistory.Count;
        }


        /** 
         *  Шаг вперед по времени.
         */
        public List<double> GoForwardInTime()
        {
            var newTime = CurrentTime + 1;

            if (newTime == OperationHistory.Count - 1)
            {
                StopTraveling();
                return Numbers;
            }

            if (newTime - startingTime_ >= travelBuffer_.Count)
            {
                travelBuffer_ = new List<List<double>>();
                int res_it = -1;
                for (var it = 0; it < DataHistory.Count; it++)
                {
                    if (DataHistory[it].Item2 >= newTime)
                    {
                        res_it = it;
                        break;
                    }
                }
                var snd_time = res_it + 1 == DataHistory.Count ? OperationHistory.Count - 1 : DataHistory[res_it + 1].Item2;

                startingTime_ = DataHistory[res_it].Item2;
                var start_list = new List<double>(DataHistory[res_it].Item1);
                travelBuffer_.Add(start_list);
                List<double> cur_list = start_list;
                CurrentTime = startingTime_ + 1;
                for (var it = startingTime_ + 1; it < snd_time; it++)
                {
                    cur_list = new List<double>(OperationHistory[it](cur_list));
                    CurrentTime++;
                    travelBuffer_.Add(cur_list);
                }
            }

            CurrentTime = newTime;

            var index = newTime - startingTime_;
            return travelBuffer_[index];
        }


        /**
         *  Функция вызывается после нажатия пользователем пункта в истории. 
         *  История после выбранного пукта стирается и обновляются соотвественные поля этого класса.
         */
        public void ResetTime(int index_history)
        {
            int res_it = 0;
            for (var it = DataHistory.Count - 1; it > -1; it--)
            {
                if (DataHistory[it].Item2 <= index_history)
                {
                    res_it = it;
                    break;
                }
            }
            DataHistory.RemoveRange(res_it + 1, DataHistory.Count - (res_it + 1));

            var cur_list = new List<double>(DataHistory[res_it].Item1);
            var start_time = DataHistory[res_it].Item2;

            for (var it = AppendedHistory.Count - 1; it > -1; it--)
            {
                if (AppendedHistory[it].Item2 <= index_history)
                {
                    res_it = it;
                    break;
                }
            }

            AppendedHistory.RemoveRange(res_it + 1, AppendedHistory.Count - (res_it + 1));

            OperationHistory.RemoveRange(index_history + 1, OperationHistory.Count - (index_history + 1));

            int start = index_history + 1;
            for (var cur_time = start_time + 1; cur_time <= index_history; cur_time++)
            {
                cur_list = OperationHistory[cur_time](cur_list);
            }
            Numbers = cur_list;
        }

        public void AppendToDataHistory(List<double> data)
        {
            DataHistory.Add(new Tuple<List<double>, int>(data, OperationHistory.Count - 1));
        }

        public void AppendToOperationHistory(Func<List<double>, List<double>> operation)
        {
            OperationHistory.Add(operation);
            CurrentTime = OperationHistory.Count - 1;
        }


        /**
         *  Так как идет работа со списком, а функции калькулятора работают с одним числов, то удобно
         *  было сделать функцию, которая возвращает версиюЮ делающие то же, что и первая, но применяет
         *  ее к каждому элементу массива.
         */
        public Func<List<double>, List<double>> MakeForEachVersionOf(Func<double, double> function)
        {
            Func<List<double>, List<double>> result = list =>
            {
                for (var it = 0; it < list.Count; it++)
                {
                    list[it] = function(list[it]);
                }
                return list;
            };
            return result;
        }


        /**
         *  Вспомогательная функция, которая делает комопзицию из списка функций.
         */
        public Func<List<double>, List<double>> UniteFunctions(List<Func<List<double>, List<double>>> listOfFunc)
        {
            Func<List<double>, List<double>> result = list =>
            {
                foreach (var func in listOfFunc)
                {
                    list = func(list);
                }
                return list;
            };
            return result;
        }

        /**
         *  Функция, которая уже принимает готовую композицию функций и меняет текущий список.
         */ 
        public void Apply(Func<List<double>, List<double>> overall_func)
        {
            Numbers = overall_func(Numbers);
        }

        //Далее реализации математических функций калькулятора.

        double AddValue(double init, double value)
        {
            return init + value;
        }

        double ExtractValue(double init, double value)
        {
            return init - value;
        }

        double MultiplyValue(double init, double value)
        {
            return init * value;
        }

        double DivideValue(double init, double value)
        {
            return init / value;
        }

        double PowValue(double init, double value)
        {
            return Math.Pow(init, value);
        }

        double SqrtnValue(double init, double value)
        {
            return Math.Pow(init, 1 / value);
        }

        double LogValue(double init, double value)
        {
            return Math.Log(init, value);
        }

        double SqrSolo(double init)
        {
            return init * init;
        }

        double SqrtSolo(double init)
        {
            return Math.Sqrt(init);
        }

        double FactSolo(double init)
        {
            int start = 1;
            for (var it = 1; it <= (int)init; it++)
            {
                start *= it;
            }

            return start;
        }

        List<double> MedianList(List<double> list)
        {
            var list_sorted = new List<double>(list);
            list_sorted.Sort();
            int middle = list.Count / 2;
            return new List<double> { list.Count % 2 == 1 
                ? list_sorted[middle] 
                : (list[middle - 1] + list[middle]) / 2 };
        }

        List<double> DeviationList(List<double> list)
        {
            double sum = 0;
            double dev = 0;
            for (var it = 0; it < list.Count; ++it)
            {
                sum += list[it];
            }

            double mean = sum / list.Count;
            for (var it = 0; it < list.Count; ++it)
            {
                dev += Math.Pow(list[it] - mean, 2);
            }

            return new List<double>() { Math.Sqrt(dev / list.Count) };
        }
    }
}
