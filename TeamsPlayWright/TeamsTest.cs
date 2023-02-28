namespace TeamsPlayWright
{

    // Define a test suite
    public class TeamsSendMessageToUserTest : PageTest
    {
        // [Test]
        public async Task ShouldSendMessageToUser()
        {
            // Navigate to Teams web app
            await Page.GotoAsync("https://teams.microsoft.com/");

            // Find and fill in the email input element
            await Page.FillAsync("[placeholder='Email\\, phone\\, or Skype']", "monitor2@syntheticww.onmicrosoft.com");

            // Click on the next button
            await Page.ClickAsync("[data-tid='nextButton']");

            // Find and fill in the password input element
            await Page.FillAsync("[placeholder='Password']", "");

            // Click on the sign-in button
            await Page.ClickAsync("[type='submit']");

            // Wait for the login process to complete 
            await Page.WaitForNavigationAsync();

            // Find and click on the new chat button
            await Page.ClickAsync("[data-tid='new-chat-button']");

            // Type in the email address of the user you want to send a message to
            await Page.TypeAsync(".search-input", "user-email@example.com");

            // Wait for suggestions list to appear and select first match 
            var suggestions = await Page.WaitForSelectorAsync(".suggestions-list");
            var firstSuggestion = await suggestions.QuerySelectorAsync("li");

            if (firstSuggestion != null)
            {
                await firstSuggestion.ClickAsync();
            }

            else
            {
                throw new Exception("No matching user found");
            }
        }

        [Test]
        public async Task ShouldLoginAndSendMessageToUser()
        {
            await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();

            await page.GotoAsync("https://teams.microsoft.com/");

            await page.GetByPlaceholder("Email, phone, or Skype").ClickAsync();

            await page.GetByPlaceholder("Email, phone, or Skype").FillAsync("monitor10@sigssyntheticppe.onmicrosoft.com");

            await page.GetByRole(AriaRole.Button, new() { Name = "Next" }).ClickAsync();

            await page.GetByPlaceholder("Password").ClickAsync();

            await page.GetByPlaceholder("Password").FillAsync("");

            await page.GetByRole(AriaRole.Button, new() { Name = "Sign in" }).ClickAsync();

            await page.GetByLabel("Don't show this again").CheckAsync();

            await page.GetByRole(AriaRole.Button, new() { Name = "Yes" }).ClickAsync();

            // await page.GetByRole(AriaRole.Button, new() { Name = "Dismiss" }).ClickAsync();

            await page.GetByRole(AriaRole.Button, new() { Name = "Chat Toolbar more options" }).ClickAsync();

            await page.GetByRole(AriaRole.Button, new() { Name = "New Chat (Alt+N)" }).ClickAsync();

            // await page.FrameLocator("iframe").GetByPlaceholder("Enter name, email, group or tag").ClickAsync();

            //await page.FrameLocator("iframe").GetByPlaceholder("Enter name, email, group or tag").FillAsync("brianmwasi@microsoft.com");

           // await Page.Keyboard.PressAsync("Enter");

            await page.GetByPlaceholder("Enter name, email, group or tag").FillAsync("brianmwasi@microsoft.com");

            await page.GetByRole(AriaRole.Paragraph).ClickAsync();

            await page.GetByRole(AriaRole.Textbox).PressAsync("Enter");


            // await page.FrameLocator("iframe").GetByRole(AriaRole.Region, new() { Name = "Compose" }).GetByRole(AriaRole.Textbox).ClickAsync();

            //await page.FrameLocator("iframe").GetByRole(AriaRole.Region, new() { Name = "Compose" }).GetByRole(AriaRole.Textbox).FillAsync("Ping");

            //await page.FrameLocator("iframe").GetByTitle("Send").ClickAsync();

        }
    }
}