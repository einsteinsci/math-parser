using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MathParser.Types;

namespace MathParser.TestGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		bool isLoggerShown = false;

		public MainWindow()
		{
			InitializeComponent();
		}

		private void GoBtn_Click(object sender, RoutedEventArgs e)
		{
			string input = EntryBox.Text;

			ListBoxItem inputLBI = new ListBoxItem();
			inputLBI.Content = input;
			inputLBI.HorizontalContentAlignment = HorizontalAlignment.Left;
			inputLBI.HorizontalAlignment = HorizontalAlignment.Stretch;
			HistoryBox.Items.Add(inputLBI);

			IResultValue irv = Evaluator.Evaluate(input);
			ListBoxItem outputLBI = new ListBoxItem();
			outputLBI.Content = irv.ToDisplayString();
			outputLBI.HorizontalContentAlignment = HorizontalAlignment.Right;
			outputLBI.HorizontalAlignment = HorizontalAlignment.Stretch;
			HistoryBox.Items.Add(outputLBI);

			EntryBox.Text = "";
			EntryBox.Focus();
		}

		private void Window_Initialized(object sender, EventArgs e)
		{
			Logger.OnLog += Log;
			Logger.DebugLogging = DebugLogToggle.IsChecked ?? false;

			Evaluator.Initialize();

			EntryBox.Focus();

			ShowBtn_Click(ShowBtn, null);
		}

		private void ShowBtn_Click(object sender, RoutedEventArgs e)
		{
			const double SCALE_AMOUNT = 2.92;

			if (isLoggerShown)
			{
				Width /= SCALE_AMOUNT;
				LoggerColumn.MaxWidth = 0;
				ShowBtn.Content = ">>";
				LoggerBox.Visibility = Visibility.Collapsed;
			}
			else
			{
				Width *= SCALE_AMOUNT;
				LoggerColumn.MaxWidth = double.PositiveInfinity;
				ShowBtn.Content = "<<";
				LoggerBox.Visibility = Visibility.Visible;
			}

			isLoggerShown = !isLoggerShown;
		}

		private void Log(object sender, LoggerEventArgs e)
		{
			Run category = new Run("[" + e.Category.ToUpper() + "]: ");
			category.Foreground = new SolidColorBrush(Colors.DarkSlateBlue);
			category.FontWeight = FontWeights.Bold;
			category.FontSize = 12;
			category.FontFamily = new FontFamily("Consolas");

			Run message = new Run(e.Message);
			switch (e.Level)
			{
			case LogLevel.Debug:
				message.Foreground = new SolidColorBrush(Colors.DarkGray);
				break;
			case LogLevel.Info:
				message.Foreground = new SolidColorBrush(Colors.Black);
				break;
			case LogLevel.Warning:
				message.Foreground = new SolidColorBrush(Colors.Orange);
				message.FontWeight = FontWeights.Bold;
				break;
			case LogLevel.Error:
				message.Foreground = new SolidColorBrush(Colors.Red);
				message.FontWeight = FontWeights.Bold;
				break;
			case LogLevel.Fatal:
				message.Foreground = new SolidColorBrush(Colors.DarkRed);
				message.FontWeight = FontWeights.Bold;
				break;
			default:
				break;
			}
			message.FontSize = 12;
			message.FontFamily = new FontFamily("Consolas");

			TextBlock log = new TextBlock();
			log.Inlines.Add(category);
			log.Inlines.Add(message);

			LoggerBox.Items.Add(log);
			LoggerBox.ScrollIntoView(log);
		}

		private void DebugLogToggle_Click(object sender, RoutedEventArgs e)
		{
			Logger.DebugLogging = !Logger.DebugLogging;
		}
	}
}
