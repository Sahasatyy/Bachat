using DataModel.Model;


namespace Bachat.Components.Pages
{
    public partial class Addtransaction
    {
        private string CustomTagInput = string.Empty; // Input for custom tag
        private List<string> CustomTags = new(); // List of custom tags
        private string SelectedTag = string.Empty; // Selected tag in dropdown

        private void Cancel()
        {
            Nav.NavigateTo("/home");
        }

        public TransactionModel Transaction { get; set; } = new TransactionModel();

        public string? message = null;

        public async Task submitTransaction()
        {
            Transaction.TransactionDate = DateTime.Now;
            if (Enum.TryParse(SelectedTag, out TransactionTag parsedTag))
            {
                Transaction.TransactionTag = parsedTag; // Assign parsed enum value
            }
            else
            {
                
                Console.WriteLine("Selected tag is not a predefined TransactionTag.");
                Transaction.TransactionTag = TransactionTag.other;
            }


            if (await TransactionService.CreateTransaction(Transaction))
            {
                message = "success";
                Nav.NavigateTo("/home", forceLoad: true);
            }
            else
            {
                message = "failed";
            }
        }

        public IEnumerable<string> GetAllTags()
        {
            // Combine predefined enum tags and custom tags
            var enumTags = Enum.GetValues(typeof(TransactionTag)).Cast<TransactionTag>().Select(tag => tag.ToString());
            return enumTags.Concat(CustomTags);
        }

        public void AddCustomTag()
        {
            if (!string.IsNullOrWhiteSpace(CustomTagInput) && !CustomTags.Contains(CustomTagInput))
            {
                CustomTags.Add(CustomTagInput); // Add the custom tag
                CustomTagInput = string.Empty; // Clear the input
                StateHasChanged(); // Notify UI of the change
            }
        }
    }
}
