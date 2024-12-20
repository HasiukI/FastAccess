using GlobalHotKey;
using System.Windows;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using WindowsInput;

namespace FastAccess.ViewModels.Components
{
    class HotKeyViewModel : BaseViewModel
    {
        private readonly HotKeyManager _hotKeyManager;
        private bool isKeyAPressed;
        private bool isKeyFPressed;

        public HotKeyViewModel()
        {
             _hotKeyManager = new HotKeyManager();

            _hotKeyManager.Register(Key.A, ModifierKeys.None);
            _hotKeyManager.Register(Key.F, ModifierKeys.None);
            _hotKeyManager.KeyPressed += _hotKeyManager_KeyPressed;

        }

        private void _hotKeyManager_KeyPressed(object? sender, KeyPressedEventArgs e)
        {
            if (e.HotKey.Key == Key.F) 
            {
                isKeyFPressed = e.HotKey.Modifiers == ModifierKeys.None; 
            }
            if (e.HotKey.Key == Key.A) {
                isKeyAPressed = e.HotKey.Modifiers == ModifierKeys.None; 
            } 
            
            // Перевірка, чи натиснуті обидві клавіші
            if (isKeyFPressed && isKeyAPressed) { 
                OnHotKeyPressed(); 
            }
        }

        public event Action HotKeyPressed;
        protected virtual void OnHotKeyPressed()
        {
            HotKeyPressed?.Invoke();
        }

        public void Dispose()
        {
            _hotKeyManager.Dispose();
        }

    }
}
