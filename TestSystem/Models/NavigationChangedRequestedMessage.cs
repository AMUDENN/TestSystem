using CommunityToolkit.Mvvm.Messaging.Messages;

namespace TestSystem.Models
{
    public class NavigationChangedRequestedMessage : ValueChangedMessage<NavigationModel>
    {
        public NavigationChangedRequestedMessage(NavigationModel model) : base(model) { }
    }
}
