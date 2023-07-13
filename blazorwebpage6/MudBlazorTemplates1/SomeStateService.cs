namespace MudBlazorTemplates1
{
    public class SomeStateService
    {
        public bool isFahrenheit { get; set; }
        public event Func<object, Task> RefreshView;

        public async Task ToggleFahrenheit()
        {
            isFahrenheit = !isFahrenheit;
            Console.WriteLine($"Some State is now {isFahrenheit}");
            await TriggerRefreshView();
        }
        public Task TriggerRefreshView() => TriggerEventAsync(RefreshView);

        private async Task TriggerEventAsync(Func<object, Task> eventHandler)
        {
            if (eventHandler != null)
            {
                await eventHandler.Invoke(this);
            }
        }
    }
}
