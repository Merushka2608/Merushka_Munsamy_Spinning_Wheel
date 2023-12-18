using Aspose.PSD.FileFormats.Psd;
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
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
	/*
	Name: Merushka Munsamy
	Assessment: 1
	*/
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

		}

		private int SelectWinAmount() //function to determine what option user selected
		{

			if (rbtnYellow.IsChecked == true)
			{
				return 252; //angle to land on yellow segment (R50)
			}
			else if (rbtnPurple.IsChecked == true)
			{
				return 180; //angle to land on purple segment (R25)
			}
			else if (rbtnBlue.IsChecked == true)
			{
				return 216; //angle to land on blue segment (R10)
			}
			else if (rbtnRed.IsChecked == true)
			{
				return 360; //angle to land on red segment (R100)
			}
			else
			{

				return 18; //angle to land on green segment (R5)
			}
		}

		private void btnSpin_Click_1(object sender, RoutedEventArgs e)
		{
			PlayTickAudio(); //tick sound

			SelectWinAmount(); //calling function to determine what option user selected

			Point center = new Point(imgWheel.ActualWidth / 2, imgWheel.ActualHeight / 2); //to make wheel only rotate from its centre point

			imgWheel.RenderTransformOrigin = new Point(0.5, 0.5);

			DoubleAnimation doubleAnimation = new DoubleAnimation //spinning animation
			{
				From = 0.0,
				To = (360 + SelectWinAmount()), //to ensure colour that user selected is behind the pin
				Duration = new Duration(TimeSpan.FromSeconds(4)) //wheel spins for at least 4 seconds
			};

			Storyboard storyBoard = new Storyboard(); //object to enable organisation of animation components

			imgWheel.RenderTransform = new RotateTransform();

			storyBoard.Children.Add(doubleAnimation);
			Storyboard.SetTarget(doubleAnimation, imgWheel);
			Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath("RenderTransform.Angle"));

			storyBoard.Begin();

		}
		private void PlayTickAudio()
		{
			MediaPlayer mediaPlayer = new MediaPlayer();
			
			mediaPlayer.Open(new Uri("/Tick.wav", UriKind.RelativeOrAbsolute));
			mediaPlayer.Position = TimeSpan.Zero;
			mediaPlayer.Play();
		}


	}


}
