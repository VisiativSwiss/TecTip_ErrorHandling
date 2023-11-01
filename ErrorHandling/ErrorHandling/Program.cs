using SolidWorks.Interop.sldworks;
using System;

namespace ErrorHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SldWorks solidworksApp = new SldWorks();
            try
            {
                // Attempt to add a new feature to the part
                var part = solidworksApp.ActiveDoc as PartDoc;
                if (part == null)
                {
                    throw new InvalidOperationException("No active document found.");
                }
                part.AddFeatureXYZ(); // Hypothetical method that adds a feature
            }
            catch (InvalidOperationException ex)
            {
                // Specific handling for InvalidOperationException
                LogError(ex);
                UserFeedback("The document is not loaded correctly.");
            }
            catch (Exception ex)
            {
                // General error handling for all other types of exceptions
                LogError(ex);
                UserFeedback("An unexpected error has occurred.");
            }
            finally
            {
                // Cleanup operations
                Cleanup();
            }
        }

        private static void Cleanup()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private static void LogError(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        private static void UserFeedback(string message)
        {
            Console.Write("Feedback: " + message);
        }
    }
}
