using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Data;
using FilmFilter.Data;
using System.Windows.Controls;

namespace FilmFilter.ViewModel
{
    class FilmViewModel:DependencyObject
    {
        #region Filtering by genre
        public string GenreText
        {
            get { return (string)GetValue(GenreFilterProperty); }
            set { SetValue(GenreFilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GenreFilterProperty =
            DependencyProperty.Register("GenreText", typeof(string), typeof(FilmViewModel), new PropertyMetadata("", GenreFilter_Changed));

        private static void GenreFilter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as FilmViewModel;
            if(current!=null)
            {
                current.Items.Filter = null;
                current.Items.Filter=current.Filter;
            }
        }
        #endregion

        #region Filtering by country
        public string CountryText
        {
            get { return (string)GetValue(CountryFilterProperty); }
            set { SetValue(CountryFilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountryFilterProperty =
            DependencyProperty.Register("CountryText", typeof(string), typeof(FilmViewModel), new PropertyMetadata("", CountryFilter_Changed));

        private static void CountryFilter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as FilmViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.Filter;
            }
        }

        #endregion

        #region Filtering by director
        public string DirectorText
        {
            get { return (string)GetValue(DirectorFilterProperty); }
            set { SetValue(DirectorFilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DirectorFilterProperty =
            DependencyProperty.Register("DirectorText", typeof(string), typeof(FilmViewModel), new PropertyMetadata("", DirectorFilter_Changed));

        private static void DirectorFilter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as FilmViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.Filter;
            }
        }
        #endregion

        #region Filtering by actor
        public string ActorText
        {
            get { return (string)GetValue(ActorFilterProperty); }
            set { SetValue(ActorFilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ActorFilterProperty =
            DependencyProperty.Register("ActorText", typeof(string), typeof(FilmViewModel), new PropertyMetadata("", ActorFilter_Changed));

        private static void ActorFilter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as FilmViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.Filter;
            }
        }

        #endregion

        #region Filtering by year
        public string YearText
        {
            get { return (string)GetValue(YearFilterProperty); }
            set { SetValue(YearFilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YearFilterProperty =
            DependencyProperty.Register("YearText", typeof(string), typeof(FilmViewModel), new PropertyMetadata("", YearFilter_Changed));

        private static void YearFilter_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as FilmViewModel;
            if (current != null)
            {
                current.Items.Filter = null;
                current.Items.Filter = current.Filter;
            }
        }
        #endregion

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(FilmViewModel), new PropertyMetadata(null));

        public  FilmViewModel()
        {
            movie[] source = movieCollection.GetMovies();
            Items = CollectionViewSource.GetDefaultView(source);
            //Items.Filter += new FilterEventHandler(GenreFilter);
        }
        private bool Filter(object obj)
        {
            bool result = true;
            movie current = obj as movie;
            if (!string.IsNullOrWhiteSpace(CountryText) && current != null && current.country != CountryText)
            {
                result &= false;
            }
            string needYear = YearText;
            ushort year = 0;
            ushort.TryParse(needYear, out year);
            if (year!=0 && current != null && current.year != year)
            {
                result &= false;
            }
            if (!string.IsNullOrWhiteSpace(GenreText) && current != null && current.genre != GenreText)
            {
                result &= false;
            }
            if (!string.IsNullOrWhiteSpace(DirectorText) && current != null && !current.director.info.Contains(DirectorText))
            {
                result &= false;
            }
            if (!string.IsNullOrWhiteSpace(ActorText) && current != null && !current.actorsAll.Contains(ActorText))
            {
                result &= false;
            }
            return result;
        }
        private bool GenreFilter(object obj)
        {
            bool result = true;
            movie current = obj as movie;
            if (!string.IsNullOrWhiteSpace(GenreText) && current != null && current.genre != GenreText)
            {
                result = false;
            }
            return result;
        }
        private bool CountryFilter(object obj)
        {
            bool result = true;
            movie current = obj as movie;
            if (!string.IsNullOrWhiteSpace(CountryText) && current != null && current.country != CountryText)
            {
                result = false;
            }
            return result;
        }
        private bool DirectorFilter(object obj)
        {
            bool result = true;
            movie current = obj as movie;
            if (!string.IsNullOrWhiteSpace(DirectorText) && current != null && !current.director.info.Contains(DirectorText))
            {
                result = false;
            }
            return result;
        }
        private bool ActorFilter(object obj)
        {
            bool result = true;
            movie current = obj as movie;
            if (!string.IsNullOrWhiteSpace(ActorText) && current != null && !current.actorsAll.Contains(ActorText))
            {
                result = false;
            }
            return result;
        }
        private bool YearFilter(object obj)
        {
            bool result = true;
            movie current = obj as movie;
            string needYear = YearText;
            ushort year = 0;
            ushort.TryParse(needYear, out year);
            if (current != null && current.year != year)
            {
                result = false;
            }
            return result;
        }
        public void GenreFilter(object sender, FilterEventArgs e)
        {
            movie current = e.Item as movie;
            if (!string.IsNullOrWhiteSpace(GenreText) && current != null && current.genre != GenreText)
            {
                e.Accepted &= false;
            }
        }
        public void YearFilter(object sender, FilterEventArgs e)
        {
            movie current = e.Item as movie;
            ushort year = 0;
            string Year = YearText;
            ushort.TryParse(Year, out year);
            if (year!=0 && current != null && current.year != year)
            {
                e.Accepted &= false;
            }
        }
    }
}