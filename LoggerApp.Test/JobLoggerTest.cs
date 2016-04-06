using LoggerApp.Logger;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace LoggerApp.Test
{
    //Naming convention used here
    //http://osherove.com/blog/2005/4/3/naming-standards-for-unit-tests.html
    [TestClass]
    public class JobLoggerTest
    {
        [TestMethod]
        [ExpectedException(typeof(LoggerException))]
        public void Log_WithAnyLoggerAndEmptyMessage_ShouldThrownLoggerException()
        {
            //arrange
            var loggerStub = new Mock<ILog>();
            var loggers = new[] { loggerStub.Object };

            var loggerHandler = new MyJobLogger(loggers,
                canLogInfo: true, canLogWarning: false, canLogError: false);

            //act
            loggerHandler.Log("", LogLevel.Info);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggerException))]
        public void Log_WithAnyLoggerAndMessageWithSomeWhiteSpaces_ShouldThrownLoggerException()
        {
            //arrange
            var loggerStub = new Mock<ILog>();
            var loggers = new[] { loggerStub.Object };

            var loggerHandler = new MyJobLogger(loggers,
                canLogInfo: true, canLogWarning: false, canLogError: false);

            //act
            loggerHandler.Log("   ", LogLevel.Info);
        }

        [TestMethod]
        [ExpectedException(typeof(LoggerException))]
        public void Log_WithAnyValidInputButSettingAllConfigurtionLevelsToFalse_ShouldThrowLoggerException()
        {
            //arrange
            var loggerMock = new Mock<ILog>();
            var loggers = new[] { loggerMock.Object };

            var loggerHandler = new MyJobLogger(loggers,
                canLogInfo: false, canLogWarning: false, canLogError: false);

            //act
            loggerHandler.Log("abc", LogLevel.Info);
        }

        [TestMethod]
        public void Log_WithMessageEqualsToabcAndLevelEqualsToInfoAndConfigureToLogOnlyInfoLevel_ShouldCallInternalLoggerWithMessageEqualsToabcAndLevelEqualsToInfo()
        {
            //arrange
            var loggerMock = new Mock<ILog>();
            var loggers = new[] { loggerMock.Object };

            var loggerHandler = new MyJobLogger(loggers,
                canLogInfo: true, canLogWarning: false, canLogError: false);

            //act
            loggerHandler.Log("abc", LogLevel.Info);

            //assert
            loggerMock.Verify(mock => mock.Log("abc", LogLevel.Info));
        }

        [TestMethod]
        public void Log_WithMessageEqualsToabcAndLevelEqualsToInfoAndConfigureToNotLogInfo_ShouldNeverToCallToInternalLoggerMethod()
        {
            //arrange
            var loggerMock = new Mock<ILog>();
            var loggers = new[] { loggerMock.Object };

            var loggerHandler = new MyJobLogger(loggers,
                canLogInfo: false, canLogWarning: true, canLogError: true);

            //act
            loggerHandler.Log("abc", LogLevel.Info);

            //assert
            loggerMock.Verify(mock => mock.Log("abc", LogLevel.Info), Times.Never);
        }
     }
}
