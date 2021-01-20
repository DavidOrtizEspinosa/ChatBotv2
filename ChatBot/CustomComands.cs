using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChatBot
{
    public static class CustomComands
    {
        public static readonly RoutedUICommand New = new RoutedUICommand(
            "Nuevo",
            "New", 
            typeof(CustomComands),
            new InputGestureCollection
            {
                new KeyGesture(Key.N, ModifierKeys.Control)
            }

            );
        public static readonly RoutedUICommand Save = new RoutedUICommand(
            "Guardar",
            "Save",
            typeof(CustomComands),
            new InputGestureCollection
            {
                new KeyGesture(Key.G, ModifierKeys.Control)
            }

            );
        public static readonly RoutedUICommand Exit = new RoutedUICommand(
            "Salir",
            "Exit",
            typeof(CustomComands),
            new InputGestureCollection
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }

            );
        public static readonly RoutedUICommand Config = new RoutedUICommand(
            "Configuración",
            "Config",
            typeof(CustomComands),
            new InputGestureCollection
            {
                new KeyGesture(Key.C, ModifierKeys.Control)
            }

            );
        public static readonly RoutedUICommand Conexion = new RoutedUICommand(
            "Conexión",
            "Conexion",
            typeof(CustomComands),
            new InputGestureCollection
            {
                new KeyGesture(Key.O, ModifierKeys.Control)
            }

            );
        public static readonly RoutedUICommand Send = new RoutedUICommand(
            "Enviar",
            "Send",
            typeof(CustomComands),
            null
            );
    }
}
