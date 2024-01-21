using System;
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace ai_assistan2.Plugins
{
	public class SocialStylePlugins
	{
		private Kernel kernel;
		public SocialStylePlugins(Kernel kernel)
		{
			this.kernel = kernel;

        }

        [KernelFunction, Description("Provides communication approach for efficient communication between collegues based on  their social style")]
		public async Task<string> GetCommunicationApproach(
            [Description("my social style")] string mySocialStyle,
            [Description("teammate social style")] string teammateSocialStyle,
            [Description("my social style info")] string mySocialStyleInfo,
            [Description("teammate social style info")] string teammateSocialStyleInfo,
            [Description("question")] string question)
        {
			string prompt = @"" +
				$"My social style is {mySocialStyle}" +
                $"My social style is {mySocialStyle} and info about it {mySocialStyleInfo}" +
                $"I need help in communicating with my teammate with social syle {teammateSocialStyle} and info about it {teammateSocialStyleInfo}" +
                $"Tell me how my social style should be ameneded to make effective communication with my teammate. Suggest messages examples.";

			var result = await kernel.InvokePromptAsync(prompt);

			return result.ToString();

        }

        [KernelFunction, Description("Provides email tempate  for efficient communication between collegues based on  their social style")]
        public async Task<string> WriteEmail(
    [Description("my social style")] string mySocialStyle,
    [Description("teammate social style")] string teammateSocialStyle,
    [Description("my social style info")] string mySocialStyleInfo,
    [Description("teammate social style info")] string teammateSocialStyleInfo,
    [Description("question")] string question)
        {
            string prompt = @"" +
                $"My social style is {mySocialStyle} and info about it {mySocialStyleInfo}" +
                $"I need help in communicating with my teammate with social syle {teammateSocialStyle} and info about it {teammateSocialStyleInfo}" +
                $"This is my ask {question}. Provide best way to write email to John " +
                $"";

            var result = await kernel.InvokePromptAsync(prompt);

            return result.ToString();

        }
    }
}

