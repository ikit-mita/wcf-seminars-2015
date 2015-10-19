using System.ComponentModel.Composition;

namespace BookStore.BusinessLogic.WCF.BooksWcfService
{
    [Export]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    partial class BooksWcfServiceClient
    {
    }
}
