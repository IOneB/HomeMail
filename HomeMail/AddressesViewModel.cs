using HomeMail.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace HomeMail
{
    public class AddressesViewModel : INotifyCollectionChanged
    {
        public ObservableCollection<string> Source { get; set; }

        readonly Repository _repos = new Repository();

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public AddressesViewModel()
        {
            Source = new ObservableCollection<string>(_repos.GetAll());
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
        }


        internal void Add(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || Source.Contains(text))
                return;

            Source.Add(text);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add));
            _repos.Add(text);
        }

        internal void Remove(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || !Source.Contains(text))
                return;

            Source.Remove(text);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove));
            _repos.Remove(text);
        }
    }
}