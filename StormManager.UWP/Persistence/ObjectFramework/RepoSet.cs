using StormManager.UWP.Common;
using StormManager.UWP.Common.SqlTransactions;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;

namespace StormManager.UWP.Persistence.ObjectFramework
{
    public class RepoSet<TEntity> : ObservableCollectionEx<TEntity> where TEntity : class, INotifyPropertyChanged
    {
        internal string AddStoredProcedureName { get; set; }
        internal string UpdateStoredProcedureName { get; set; }
        internal string DeleteStoredProcedureName { get; set; }
        internal string GetAllStoredProcedureName { get; set; }


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
                RepoChanges.Changes.Enqueue(new StateChange(sender, SqlTransactionType.Update));
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Debugger.Break();
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ProcessInsertions(e);

            ProcessDeletions(e);
        }

        private void ProcessInsertions(NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                ProcessModifications(e.NewItems, SqlTransactionType.Insertion);
        }

        private void ProcessModifications(System.Collections.IList collection, SqlTransactionType sqlTransactionType)
        {
            foreach (var modification in collection)
            {
                if (!(modification is TEntity entity) || RepoChanges.QueueContains(entity))
                    continue;

                RepoChanges.Changes.Enqueue(new StateChange(entity, sqlTransactionType));
                entity.PropertyChanged += ItemOnPropertyChanged;
            }
        }

        private void ProcessDeletions(NotifyCollectionChangedEventArgs e)
        {
            if (e.OldItems != null)
                ProcessModifications(e.OldItems, SqlTransactionType.Deletion);
        }
    }
}
