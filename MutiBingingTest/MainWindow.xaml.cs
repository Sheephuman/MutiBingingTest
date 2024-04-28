using System.ComponentModel;
using System.Windows;

namespace MutiBingingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private string _userInput = string.Empty;



        //ユーザー入力用文字列
        public string UserInput
        {
            get => _userInput;
            set
            {
                if (_userInput != value)
                {
                    _userInput = value;
                    StringB = value;  // ここを変更
                    OnPropertyChanged(nameof(UserInput));
                  
                    //$"-b:v {value}"
                }
            }
        }


        // ビューモデルのプロパティを公開するためのプロパティ
        private string _stringB = string.Empty;
        // INotifyPropertyChangedのイベント
        public event PropertyChangedEventHandler? PropertyChanged;

        // StringBプロパティ
        public string StringB
        {
            get { return _stringB; }
            set
            {

                    _stringB = $"-b:v {value}k";
                    OnPropertyChanged(nameof(StringB));  // 変更通知

                
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            // ビューモデルまたはコードビハインドのプロパティに初期値を設定

            DataContext = this;
         
        }
        // プロパティが変更された時にUIに通知するためのヘルパーメソッド
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}