using System;
using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace ai_assistan2
{
	public class GetSocialInfo
	{

        [KernelFunction, Description(@"Find social style of employee by name")]
        public string FindSocialStyleByName(
            [Description("name")] string employeeName)
        { 
            switch (employeeName)
            {
                case "AK":
                    return "DRIVER";
                case "SA":
                    return "AMIABLE";
                case "AB":
                    return "ANALYTICAL";
                case "SP":
                    return "DRIVER";
                case "KA":
                    return "DRIVER";
                default:
                    return "Unknown social style";
            }
        }

            [KernelFunction, Description(@"Helps to identify alternation for communication with different social styles")]
        public string HowShouldIAlterMyCommuicationStyle(
                        [Description("my social style")] string mySocialStyle,
                        [Description("teammate social style")] string teammateSocialStyle)
        {
            if (mySocialStyle == "DRIVER" && teammateSocialStyle == "DRIVER")
            {
                return "Maintain peer status, share the responsibilities of leadership";
            }
            else if (mySocialStyle == "DRIVER" && teammateSocialStyle == "Expressive")
            {
                return "Shift your focus to a more general outlook, be less formal";
            }
            else if (mySocialStyle == "DRIVER" && teammateSocialStyle == "AMIABLE")
            {
                return "Slow your pace and focus more on the relationships";
            }
            else if (mySocialStyle == "DRIVER" && teammateSocialStyle == "ANALYTICAL")
            {
                return "Focus on some detail in relation to the goals";
            }
            else if (mySocialStyle == "Expressive" && teammateSocialStyle == "DRIVER")
            {
                return "Shift focus more toward the goal, less generalities. Be a little less casual";
            }
            else if (mySocialStyle == "Expressive" && teammateSocialStyle == "Expressive")
            {
                return "Listen more, take notes, don’t try to outtalk each other";
            }
            else if (mySocialStyle == "Expressive" && teammateSocialStyle == "AMIABLE")
            {
                return "Slow your pace and focus more on the relationship";
            }
            else if (mySocialStyle == "Expressive" && teammateSocialStyle == "ANALYTICAL")
            {
                return "Focus on some detail in relation to the goals";
            }
            else if (mySocialStyle == "AMIABLE" && teammateSocialStyle == "DRIVER")
            {
                return "Shift focus more toward the goal, less generalities";
            }
            else if (mySocialStyle == "AMIABLE" && teammateSocialStyle == "Expressive")
            {
                return "Pick up the pace, focus less on the relationship";
            }
            else if (mySocialStyle == "AMIABLE" && teammateSocialStyle == "AMIABLE")
            {
                return "Focus more on the issues at hand and less on popularity and networking";
            }
            else if (mySocialStyle == "AMIABLE" && teammateSocialStyle == "ANALYTICAL")
            {
                return "Focus less on the relationship and more on details";
            }
            else if (mySocialStyle == "ANALYTICAL" && teammateSocialStyle == "DRIVER")
            {
                return "Pick up the pace and focus less on details and more on the goal";
            }
            else if (mySocialStyle == "ANALYTICAL" && teammateSocialStyle == "Expressive")
            {
                return "Focus a little less on detail. Be a little more casual";
            }
            else if (mySocialStyle == "ANALYTICAL" && teammateSocialStyle == "AMIABLE")
            {
                return "Focus a little more on the relationship. Be more casual";
            }
            else if (mySocialStyle == "ANALYTICAL" && teammateSocialStyle == "ANALYTICAL")
            {
                return "Try to look at ideas more objectively. You both need to be right";
            }
            else
            {
                return "Invalid combination of personalities";
            }
        }

    }
}

