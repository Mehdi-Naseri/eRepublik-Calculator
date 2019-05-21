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

namespace eRepublicCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CalculateDamage();
            CalculateInfluence();
        }

        private void CalculateDamage()
        {
            //   D = (60 + ((S1-S2)/10)) × (1 + (Your FirePower-Enemys FirePower)/400) / 2
            //D: Damage 
            //S1: Your Strength 
            //S2: Enemy's Strength
            try
            {
                textBoxDamage.Text = ((60 + ((int.Parse(textBoxYourStrength.Text) - int.Parse(textBoxEnemyStrength.Text)) / 10)) * (1 + (int.Parse(textBoxYourFirePower.Text) - int.Parse(textBoxEnemyFirePower.Text)) / 400) / 2).ToString();
            }
            catch
            {
            }
        }
        private void CalculateInfluence()
        {
            //   I = 10 × (1 +S/400) × (1 +R/5) × (1 +FirePower/100)
            //I: Influence on the hit 
            //R: Value of the Rank 
            //S: Strength
            try
            {
                textBoxInfluenceOnTheHit.Text = (10 * (1 + int.Parse(textBoxStrength.Text) / 400) * (1 + int.Parse(textBoxValueOfTheRank.Text) / 5) * (1 + int.Parse(textBoxFirePower.Text) / 100)).ToString();
            }
            catch
            {
            }
       }

        private void CalculateDamage_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalculateDamage();
        }
        private void CalculateInfluence_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CalculateInfluence();
        }

        private void textBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            System.Text.RegularExpressions.Regex regex1 = new System.Text.RegularExpressions.Regex("[^0-9]");
            e.Handled = regex1.IsMatch(e.Text);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.erepublik.com/en/citizen/profile/7385746");
        }


    }
}
