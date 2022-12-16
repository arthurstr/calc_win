using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private Calculator calculator_;
        private string prev_context_ = String.Empty;
        private string filename_ = String.Empty;
        private bool appendedAndNotApplied_ = false;

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = mainTextBox;
            calculator_ = new Calculator();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            var operations = new List<Func<List<double>, List<double>>>();
            var splited = contextTextBox.Text.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var func_pair in splited)
            {
                var func_and_arg = func_pair.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
                var func_name = func_and_arg[0];
                if (func_and_arg.Length == 1)
                {
                    if (calculator_.Operations.ContainsKey(func_name))
                    {
                        var funcWithNoArg = calculator_.Operations[func_name];
                        var forEachVersionOfFunc = calculator_.MakeForEachVersionOf(funcWithNoArg);
                        operations.Add(forEachVersionOfFunc);
                    }
                    else
                    {
                        var forEachVersionOfFunc = calculator_.OperationsReduce[func_name];
                        operations.Add(forEachVersionOfFunc);
                    }
                }
                else
                {
                    var arg = Double.Parse(func_and_arg[1]);
                    var funcWithArg = calculator_.OperationsWithArg[func_name];
                    Func<double, double> funcWithNoArg = value => funcWithArg(value, arg);
                    var forEachVersionOfFunc = calculator_.MakeForEachVersionOf(funcWithNoArg);
                    operations.Add(forEachVersionOfFunc);
                }
            }

            var overallFunc = calculator_.UniteFunctions(operations);

            if (calculator_.IsTravelling)
            {
                var curTime = calculator_.CurrentTime;
                calculator_.ResetTime(curTime);
                calculator_.StopTraveling();

                while (historyListBox.Items.Count > curTime + 1)
                {
                    historyListBox.Items.RemoveAt(historyListBox.Items.Count - 1);
                }

                UndoButton.Enabled = (!calculator_.IsTravelling && calculator_.OperationHistory.Count > 1) ||
                    (calculator_.IsTravelling && calculator_.CurrentTime > 0);
                RepeatButton.Enabled = calculator_.IsTravelling;

                timeLabel.Visible = false;
            }

            calculator_.AppendToOperationHistory(overallFunc);

            var prevCount = calculator_.Numbers.Count;
            calculator_.Apply(overallFunc);
            var curCount = calculator_.Numbers.Count;

            if (curCount == 1 && prevCount != 1)
            {
                calculator_.AppendToDataHistory(new List<double>(calculator_.Numbers));
            }

            prev_context_ = contextTextBox.Text;
            historyListBox.Items.Add(historyListBox.Items.Count + ") " + prev_context_);

            contextTextBox.Text = "";
            textBox1.Text = String.Join(", ", calculator_.Numbers);

            SaveButton.Enabled = true;
            AppendButton.Enabled = true;
            FixButton.Enabled = false;

        }

        private void AddCalculationButton_Click(object sender, EventArgs e)
        {
            var splited = mainTextBox.Text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            bool expectingNumber = false;
            string buffer = "";
            foreach (var str in splited)
            {
                if (!expectingNumber && calculator_.IsOperation(str))
                {
                    if (calculator_.IsArgumentNeededForOperation(str))
                    {
                        expectingNumber = true;
                        buffer = str;
                    }
                    else
                    {
                        contextTextBox.AppendText(str + ";");
                    }
                }
                else if (expectingNumber && !calculator_.IsOperation(str))
                {
                    try
                    {
                        double value = Double.Parse(str);
                        contextTextBox.AppendText(buffer + " " + str + ";");
                        buffer = "";
                        expectingNumber = false;
                    }
                    catch (FormatException ex)
                    {
                        break;
                    }
                    catch (OverflowException ex)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            mainTextBox.Text = "";
        }

        private void AppendButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<double> temp = new List<double>();
                foreach (var str in mainTextBox.Text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries ))
                {
                    double value = Double.Parse(str);
                    temp.Add(value);
                }

                foreach (var el in temp)
                {
                    calculator_.AppendNumber(el);
                }
                appendedAndNotApplied_= true;
                FixButton.Enabled = true;
            }
            catch (FormatException ex)
            {
            }
            catch (OverflowException ex)
            {
            }

            mainTextBox.Text = "";
            textBox1.Text = String.Join(", ", calculator_.Numbers);
            SaveButton.Enabled = false;
        }

        private void ContextTextBox_TextChanged(object sender, EventArgs e)
        {
            ApplyButton.Enabled = (contextTextBox.Text != "") && (appendedAndNotApplied_ == false) && (calculator_.Numbers.Count > 0);
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" * ");
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" / ");
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" + ");
        }

        private void ExtractButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" - ");
        }

        private void PowButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" pow ");
        }

        private void SqrtnButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" sqrtn ");
        }

        private void LogButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" log ");
        }

        private void SqrButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" sqr ");
        }

        private void SqrtButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" sqrt ");
        }

        private void FactButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" fact ");
        }

        private void MedianButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" median ");
        }

        private void DeviationButton_Click(object sender, EventArgs e)
        {
            mainTextBox.AppendText(" deviation ");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            contextTextBox.Text = "";
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            calculator_.AppendToDataHistory(new List<double>(calculator_.Numbers));
            foreach (var tuple in calculator_.DataHistory)
            {
                Console.WriteLine(tuple.Item2);
                foreach (var el in tuple.Item1)
                {
                    Console.Write(el + " ");
                }
                Console.WriteLine();
            }
            SaveButton.Enabled = false;
        }

        private void HistoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var it = historyListBox.SelectedIndex;
            if (it == -1)
            {
                return;
            }

            calculator_.ResetTime(it);
            while (historyListBox.Items.Count > it + 1)
            {
                historyListBox.Items.RemoveAt(historyListBox.Items.Count - 1);
            }

            textBox1.Text = String.Join(", ", calculator_.Numbers);
        }

        private void RepeatButton_Click(object sender, EventArgs e)
        {
            if (!calculator_.IsTravelling)
            {
                calculator_.StartTraveling();
            }

            var list = calculator_.GoForwardInTime();
            textBox1.Text = String.Join(", ", list);

            if (!calculator_.IsTravelling)
            {
                timeLabel.Visible = false;
                historyListBox.Enabled = true;
                return;
            }

            timeLabel.Text = calculator_.CurrentTime.ToString() + " / " + (calculator_.OperationHistory.Count - 1).ToString();
            timeLabel.Visible = true;
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            if (!calculator_.IsTravelling)
            {
                calculator_.StartTraveling();
            }

            var list = calculator_.GoBackInTime();
            textBox1.Text = String.Join(", ", list);

            timeLabel.Text = calculator_.CurrentTime.ToString() + " / " + (calculator_.OperationHistory.Count - 1).ToString();
            timeLabel.Visible = true;

            historyListBox.Enabled = false;
        }

        private void FixButton_Click(object sender, EventArgs e)
        {
            //AppendButton.Enabled = false;
            calculator_.AppendToOperationHistoryAppend();
            historyListBox.Items.Add(historyListBox.Items.Count + ") " + 
                calculator_.AppendedHistory[calculator_.AppendedHistory.Count - 1].Item1.Count + " new added");
            appendedAndNotApplied_ = false;
            ApplyButton.Enabled = contextTextBox.Text != "";
            FixButton.Enabled = false;
            SaveButton.Enabled = true;
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (TextWriter writer = File.CreateText(filename_))
                {
                    for (var it = 0; it < calculator_.Numbers.Count - calculator_.Numbers.Count % 3; it += 3)
                    {
                        writer.WriteLine("{0} {1} {2}", calculator_.Numbers[it], calculator_.Numbers[it + 1], calculator_.Numbers[it + 2]);
                    }

                    for (var it = calculator_.Numbers.Count - calculator_.Numbers.Count % 3; it < calculator_.Numbers.Count; it++)
                    {
                        writer.Write(calculator_.Numbers[it] + " ");
                    }
                    writer.WriteLine();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader sr = File.OpenText(filename_))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var splited = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries );
                        foreach (var str in splited)
                        {
                            calculator_.AppendNumber(Double.Parse(str));
                        }
                    }
                }
                textBox1.Text = String.Join(", ", calculator_.Numbers);
                appendedAndNotApplied_= true;
                FixButton.Enabled = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addFilenameButton_Click(object sender, EventArgs e)
        {
            filename_ = mainTextBox.Text;

            if (filename_ != "")
            {
                importButton.Enabled = true;
                exportButton.Enabled = true;
            }
            else
            {
                importButton.Enabled = false;
                exportButton.Enabled = false;
            }

            mainTextBox.Text = "";
            filenameLabel.Text = filename_;
            filenameLabel.Visible = true;
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            UndoButton.Enabled = (!calculator_.IsTravelling && calculator_.OperationHistory.Count > 1) ||
                      (calculator_.IsTravelling && calculator_.CurrentTime > 0);
            RepeatButton.Enabled = calculator_.IsTravelling;
            ApplyButton.Enabled = (contextTextBox.Text != "") && (appendedAndNotApplied_ == false) && (calculator_.Numbers.Count > 0);
        }

        private void clearDataButton_Click(object sender, EventArgs e)
        {
            if (calculator_.Numbers.Count > 0)
            {
                calculator_.ClearNumbers();
                textBox1.Text = string.Empty;
                historyListBox.Items.Add(historyListBox.Items.Count + ") " + "clear");
            }
        }
    }
}
