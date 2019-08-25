using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using StormManager.UWP.Common;

namespace StormManager.UWP.Persistence.ObjectFramework
{
    public class RepoSet<TEntity> : ObservableCollectionEx<TEntity> where TEntity : class, INotifyPropertyChanged
    {
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
            RepoChanges.Changes = new Queue<StateChange>();

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
            if (!RepoChanges.QueueContains(sender))
                RepoChanges.Changes.Enqueue(new StateChange(sender, DataManipulation.Update));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debugger.Break();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (var addedItem in e.NewItems)
            {
                if (!(addedItem is TEntity entity))
                    continue;

                if (!RepoChanges.QueueContains(entity))
                    RepoChanges.Changes.Enqueue(new StateChange(entity, DataManipulation.Insertion));
            }
        }
    }
}
