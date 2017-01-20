﻿using AisProjectASP.Models;
using AisProjectASP.Utils;
using NUnit.Framework;
using System;
using System.Linq;

namespace AisProjectASP.Tests.CacheTests
{
    [TestFixture]
    public class MessagesTests
    {
        ICacheHelper helper = new CacheHelper();


        [SetUp]
        public void Init()
        {
            helper.CreateMessages();
        }

        [Test]
        public void CheckFirstMessagesSize()
        {
            //given
            //when
            var listOfMessages = helper.GetMessages();
            //then
            Assert.AreEqual(Message.START_MESSAGE_SIZE, helper.GetMessages().Count);
            helper.ClearMessages();
        }

        [Test]
        public void CheckAddingOneMessages()
        {
            //given
            // helper.CreateMessages();
            //when
            helper.SaveMessage(new Message(1111, "someTitle", "somebody", DateTime.Now));
            //then
            Assert.AreEqual(Message.START_MESSAGE_SIZE + 1, helper.GetMessages().Count);
            helper.ClearMessages();
        }

        [Test]
        public void ShouldDeleteMessage()
        {
            //given
            //helper.CreateMessages();
            //when
            helper.DeleteMessage(5);
            //then
            Assert.AreEqual(Message.START_MESSAGE_SIZE - 1, helper.GetMessages().Count);
            helper.ClearMessages();
        }

        [Test]
        public void ShouldUpdateMessage()
        {
            //given
            //helper.CreateMessages();
            string newTitle = "newTitle123";
            string someBody = "someBody123";
            int initialId = 5;
            //when
            helper.UpdateMessage(new Message(initialId, newTitle, someBody, DateTime.Now));
            Message msg = helper.GetMessages().FirstOrDefault(m => m.Id == initialId);
            //then
            Assert.AreEqual(newTitle, msg.Title);
            Assert.AreEqual(someBody, msg.Body);
            helper.ClearMessages();
        }
    }
}
