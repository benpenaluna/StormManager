using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using StormManager.UWP.Common;

namespace StormManager.UWP.Persistence.Repositories
{
    public class RepoSet<TEntity> : ObservableCollectionEx<TEntity> where TEntity : class, INotifyPropertyChanged
    {
        private Queue<RepoChange<TEntity>> _changes;

        internal RepoSet()
        {
            Initialise();
        }

        internal RepoSet(IEnumerable<TEntity> collection) : base(collection)
        {
            Initialise();
        }

        private void Initialise()
        {
            _changes = new Queue<RepoChange<TEntity>>();

            AttachEvents();
        }


        public void AttachEvents()
        {
            CollectionChanged += OnCollectionChanged;

            foreach (var item in Items)
            {
                item.PropertyChanged += ItemOnPropertyChanged;
            }
        }

        private void ItemOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (sender.GetType() != typeof(TEntity))
                throw new ArgumentException($"{sender} is not of type {typeof(TEntity)}"); // TODO: Move literal string to Resources
            
            if (!QueueContains((TEntity)sender))
                _changes.Enqueue(new RepoChange<TEntity>((TEntity)sender, DataManipulation.Update));
        }

        private bool QueueContains(TEntity entity)
        {
            return _changes.Any(change => change.Item == entity);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debugger.Break();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debugger.Break();
        }
    }
}
