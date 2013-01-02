namespace ProvinceSpy.WpfGui.ViewModels
{
    public class ResourceViewModel : EventBasedViewModel
    {
        private Resource resourceLevel = Resource.Zero;
        public Resource ResourceLevel
        {
            get { return this.resourceLevel; }
            set
            {
                SetField(ref this.resourceLevel, value, () => this.ResourceLevel);
            }
        }

        public bool IsEnableds
        {
            get { return OnWasUpdated() == false; }
        }
    }
}