using BibDeClasses;
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

namespace ProjetRealiteVirtuelle
{
    /// <summary>
    /// Logique d'interaction pour ProjectileUserControl.xaml
    /// </summary>
    public partial class ProjectileUserControl : UserControl
    {
        public ProjectileUserControl()
        {
            InitializeComponent();
        }



        public ElemType TypeProjectile
        {
            get { return (ElemType)GetValue(TypeProjectileProperty); }
            set { SetValue(TypeProjectileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TypeProjectile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TypeProjectileProperty =
            DependencyProperty.Register("TypeProjectile", typeof(ElemType), typeof(ProjectileUserControl), new PropertyMetadata(ElemType.Unknown));

        
        

        
    }
}
