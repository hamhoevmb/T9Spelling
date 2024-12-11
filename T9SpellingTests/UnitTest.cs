using AutoMapper;
using T9Spelling;

namespace T9SpellingTests
{
    public class UnitTest
    {
        public class T9TranslatorServiceTest
        {
            private readonly IT9TranslatorService _translatorService;

            public T9TranslatorServiceTest()
            {
                var mappingService = new T9MappingService();
                var t9Mapping = mappingService.GetMapping();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new T9Profile(t9Mapping));
                });

                var mapper = configuration.CreateMapper();
                _translatorService = new T9TranslatorService(mapper);
            }

            [Fact]
            public void Translate_ShouldAddPause_ForConsecutiveSameKey()
            {
                string input = "hello";
                string expectedOutput = "4433555 555666";
                string actualOutput = _translatorService.Translate(input);
                Assert.Equal(expectedOutput, actualOutput);
            }

            [Fact]
            public void Translate_ShouldHandleRepeatedCharacters_OnSameKey()
            {
                string input = "aaa";
                string expectedOutput = "2 2 2";
                string actualOutput = _translatorService.Translate(input);
                Assert.Equal(expectedOutput, actualOutput);
            }

            [Fact]
            public void Translate_ShouldHandleMixedCharacters_OnSameKey()
            {
                string input = "abc";
                string expectedOutput = "2 22 222";
                string actualOutput = _translatorService.Translate(input);
                Assert.Equal(expectedOutput, actualOutput);
            }

            [Fact]
            public void Translate_ShouldNotAddPause_ForDifferentKeys()
            {
                string input = "dog";
                string expectedOutput = "36664";
                string actualOutput = _translatorService.Translate(input);
                Assert.Equal(expectedOutput, actualOutput);
            }

            [Fact]
            public void Translate_ShouldHandleSpaces_Correctly()
            {
                string input = "a b";
                string expectedOutput = "2022";
                string actualOutput = _translatorService.Translate(input);
                Assert.Equal(expectedOutput, actualOutput);
            }
        }
    }
}