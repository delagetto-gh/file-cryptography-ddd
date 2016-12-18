using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileCryptography.Domain.Models;
using FluentAssertions;
using FileCryptography.Domain.Interfaces.Services;
using FileCryptography.Domain.Interfaces.Events;
using FileCryptography.Domain.Events;

namespace FileCryptography.Domain.Tests.Unit.Models
{
    public class KeyPairTests
    {
        [TestClass]
        public class TheDecryptMethod
        {
            [TestMethod]
            public void ShouldRaiseFileDecryptedEvent()
            {
                MockCryptographyExecutionService cryptoSvc = new MockCryptographyExecutionService();
                MockEventDispatcher eventDispatcher = new MockEventDispatcher();
                DomainEvents.Dispatcher = eventDispatcher;
                KeyPair sut = KeyPair.Create(cryptoSvc);
                sut.Id.Should().NotBeEmpty();
                sut.PrivateKey.FileName.Should().Be("TestFile.txt");
                sut.PrivateKey.Content.Should().NotBeNull();
                sut.PublicKey.FileName.Should().Be("TestFile.txt");
                sut.PublicKey.Content.Should().NotBeNull();
                sut.PassPhrase.FileName.Should().Be("TestFile.txt");
                sut.PassPhrase.Content.Should().NotBeNull();
                eventDispatcher.Events.Count.Should().Be(1);
                eventDispatcher.Events[0].Should().BeOfType<KeyPairGeneratedEvent>();
                eventDispatcher.Events[0].AggregateId.Should().NotBeEmpty();
                eventDispatcher.Events[0].Created.Should().BeCloseTo(DateTimeOffset.Now, 100, "if you're debugging, then you're delaying the time comparison");
            }
        }
    }
}
