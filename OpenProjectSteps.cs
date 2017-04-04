using System;
using TechTalk.SpecFlow;
using TestStack.White;
using System.Windows.Automation;
using TestStack.White.UIA;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.Factory;
using TestStack.White.UIItems.MenuItems;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace UnitTestProject2
{
    [Binding]
    public class OpenProjectSteps
    {
        private static Application application;
        private static Window window;
        private static Button fileButton, open, removeFromList;
        private static Menu openProject;
        private static TextBox fileName;

        [Given(@"I have successfully loaded Translation Studio")]
        public void GivenIHaveSuccessfullyLoadedTranslationStudio()
        {
            application = Application.Launch(@"F:\SDL\Ghost\bin\Mixed Platforms\Debug\SDLTradosStudio.exe");
            window = application.GetWindow(SearchCriteria.ByAutomationId("StudioWindowForm"), InitializeOption.NoCache);
            window.WaitWhileBusy(); 
        }
        
        [When(@"I press File tab")]
        public void WhenIPressFileTab()
        {
            fileButton = window.Get<Button>(SearchCriteria.ByAutomationId("Application Menu Button"));
            fileButton.Click();
        }
        
        [When(@"I press Open Project")]
        public void WhenIPressOpenProject()
        {
            openProject = window.Get<Menu>(SearchCriteria.ByAutomationId
                          ("[Content Area Group 1 Items] Menu Item :  - Index : 1 "));
            openProject.Click();
        }
        
        [When(@"I insert Project Name")]
        public void WhenIInsertProjectName()
        {
            fileName = window.Get<TextBox>(SearchCriteria.ByAutomationId("1148"));
            open = window.Get<Button>(SearchCriteria.ByAutomationId("1"));
            fileName.Enter("Project 5");
            open.Click();
        }
        
        [When(@"I press Open")]
        public void WhenIPressOpen()
        {
            fileName.Enter("Project 5.sdlproj");
            open.Click();
        }
        
        [Then(@"The project should appear in the projects list")]
        public void ThenTheProjectShouldAppearInTheProjectsList()
        {
            string windowName = window.Name;

            removeFromList = window.Get<Button>(SearchCriteria.ByAutomationId
                            ("[Group : TasksRibbonGroup Tools] Tool : IgCommandBarAction:CloseProjectAction - Index : 5 "));
            removeFromList.Click();
            var confirmRemove = window.Get<Button>(SearchCriteria.ByAutomationId("6"));
            confirmRemove.Click();
           
            Assert.AreEqual("SDL Trados Studio - Project 5", windowName);
            application.Close();           
        }
    }
}
