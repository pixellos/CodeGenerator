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
using System.IO;
namespace CodeGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AvrPortCodeGenerator.Save(
                AvrPortCodeGenerator.Generate(Letters.Text, int.Parse(Pins.Text))
                );
            this.Close();
        }


    }

    public class AvrPortCodeGenerator
    {
        private const string PortX = @"class Port{0}{{
        public:
	    void static Set(uint8_t uCharValue)
       {{
            PORT{0} |= uCharValue;
       }}

        void static Clear(uint8_t uCharValue)
       {{
            PORT{0} &= ~(uCharValue);
       }}

        void static Toggle(uint8_t uCharValue)
       {{
            PORT{0} ^= uCharValue;
       }}

        uint8_t static Check()
       {{
            return PIN{0};
       }}

        void static AsOutput(uint8_t uCharValue)
       {{
            DDR{0} &= ~(uCharValue);
       }}

        void static AsInput(uint8_t uCharValue)
       {{
            DDR{0} |= uCharValue;
       }}
       }};";

        private const string PinXY = @"class Pin_{0}{1}{{
public:
	    void static Set()
	    {{
		    PORT{0} |= 1 << {1};
	    }}

	    void static Clear()
	    {{
		    PORT{0} &= ~(1<<{1});
	    }}

	    void static Toggle()
	    {{
		    PORT{0} ^= (1<<{1});
	    }}

	    bool Check()
	    {{
		    return ((PIN{0} >> {1}) & 1);
	    }}

	    void static AsOutput()
	    {{
		    DDR{0} &= ~(1<<{1});
	    }}

	    void static AsInput()
	    {{
		    DDR{0} |= 1<<{1};
	    }}
        }};";

        private static string GetGeneratedTextForPortX(string Letter)
        {
            return String.Format(PortX, Letter);
        }

        private static string GetGeneratedTextForPinXY(string Letter, string Number)
        {
            return String.Format(PinXY, Letter, Number);
        }

        public static string Generate(string letters, int PinCount)
        {
            var result = "";
            foreach (var chars in letters)
            {
                result += AvrPortCodeGenerator.GetGeneratedTextForPortX(chars.ToString());
                for (int i = 0; i < PinCount; i++)
                {
                    result += AvrPortCodeGenerator.GetGeneratedTextForPinXY(chars.ToString(), i.ToString());
                }
            }
            return result;
        }

        public static void Save(string result)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "headerfile"; // Default file name
            dlg.DefaultExt = ".h"; // Default file extension
            dlg.Filter = "Header files (.h)|*.h"; // Filter files by extension

            // Show save file dialog box
            bool? results = dlg.ShowDialog();

            // Process save file dialog box results
            if (results == true)
            {
                // Save document
                File.WriteAllText(dlg.FileName, result);
            }
        }
    }
}
