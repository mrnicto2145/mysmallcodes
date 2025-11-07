using System;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace TableParser;

[TestFixture]
public class QuotedFieldTaskTests
{
	[TestCase("''", 0, "", 2)]
	[TestCase("'a'", 0, "a", 3)]
	public void Test(string line, int startIndex, string expectedValue, int expectedLength)
	{
		var actualToken = QuotedFieldTask.ReadQuotedField(line, startIndex);
		ClassicAssert.AreEqual(new Token(expectedValue, startIndex, expectedLength), actualToken);
	}

	// Добавьте свои тесты

}

class QuotedFieldTask
{
	public static bool IsCharEscaped(string line, int index)
	{
		var tempIndex = index - 1;
		var c = 0;
		while (tempIndex > 0)
		{
			if (line[tempIndex] != '\\') break;
			else
			{
				tempIndex--;
				c++;
			}
		}
		return c % 2 == 1;
	}
	public static Token ReadQuotedField(string line, int startIndex)
	{
		var substring = new string("");
		for (int i = startIndex + 1; i < line.Length; i++)
		{
			if (line[i] == line[startIndex] && (!IsCharEscaped(line, i)))
			{
				return new Token(substring, startIndex, i - startIndex + 1);
			}
			if (line[i] != '\\' || IsCharEscaped(line, i))
			{
				substring += line[i];
			}
		}
		return new Token(line.Substring(startIndex + 1, line.Length - startIndex - 1), startIndex, line.Length - startIndex);
	}
}