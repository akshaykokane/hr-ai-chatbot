using System;
using Azure.AI.OpenAI;
using System.Text.Json;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using ai_assistan2.Plugins;
using Microsoft.SemanticKernel.Planning.Handlebars;
using Humanizer;

namespace ai_assistan2
{
	public class Copilot
	{
		public readonly Kernel kernel;

        private readonly Dictionary<string, string> socialStyles = new Dictionary<string, string>();

        public Copilot()
		{
            kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: "gpt-3.5-turbo-1106",
                    apiKey: "sk-key")
                .Build();

            kernel.Plugins.Add(kernel.CreatePluginFromObject(new GetSocialInfo()));
            kernel.Plugins.Add(kernel.CreatePluginFromObject(new SocialStylePlugins(kernel)));
            socialStyles.Add("John", "Driver");
            //socialStyles.Add("John", "Driver");

        }

        public async Task<ChatResponse> ChatAsync(string message)
        {
            var chat = kernel.GetRequiredService<IChatCompletionService>();
            var chatHistory = new ChatHistory();
            string prompt = @"I am ""AK"" with DRIVER social style, and I want help for communication with my team mate.
                You should first search social style of my teammate based on the name,
                then find the way I need to alter my communication style.
                Finally, help me with my ASK :" + message;

            OpenAIPromptExecutionSettings settings = new() {
                ToolCallBehavior = ToolCallBehavior.EnableKernelFunctions,
                ChatSystemPrompt = "You are coach for each team memeber to help with communication style. There are 6 members in our team. " +
                "There are 4 possible social styles: DRIVER, AMIABLE, ANALYTICAL, EXPRESSIVE"
            };
            //chatHistory.AddUserMessage();

            HandlebarsPlanner planner = new HandlebarsPlanner();

            var plan = await planner.CreatePlanAsync(kernel, prompt);

                Console.WriteLine($"Plan: {plan}");
            
            // Execute the plan
            var result = await plan.InvokeAsync(kernel, new(settings));

            // Print the result to the console
            Console.WriteLine($"Results: {result}");

            return new ChatResponse()
            {
                Response = result,
                Citations = plan.ToString()

            };

        }

        private string GetSystemPrompt()
        {
            return @"You are AI assistant which helps team with their collabrations and communication.
                    You have information about every employees social styles, and based on that information,
                    you make decision on how you can help one employee to talk with another.";
        }
	}
}

