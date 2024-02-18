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
            [Description("alteration")] string alteration,
            [Description("ask")] string ask)
        {
            string prompt = @"" +
                $"My social style is {mySocialStyle}" +
                $"I need help in communicating with my teammate with social syle {teammateSocialStyle} and this is how I should alter my style {alteration}" +
                $"Based on information help me with my ask {ask} and provide me tips for effective . Don't use external knowledge. Take into consideration mine and teammate social style and also provide example messages";

            var result = await kernel.InvokePromptAsync(prompt);

            return result.ToString();

        }
    }
}

