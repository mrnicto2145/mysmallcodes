using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace TableParser;

[TestFixture]
public class FieldParserTaskTests
{
	public static void Test(string input, string[] expectedResult)
	{
		var actualResult = FieldsParserTask.ParseLine(input);
		ClassicAssert.AreEqual(expectedResult.Length, actualResult.Count);
		for (int i = 0; i < expectedResult.Length; ++i)
		{
			ClassicAssert.AreEqual(expectedResult[i], actualResult[i].Value);
		}
	}

	[TestCase("text", new[] { "text" })]
	[TestCase("hello world", new[] { "hello", "world" })]
	[TestCase(@" ""a 'b' c""", new[] { "a 'b' c" })]
	[TestCase("'' 'a'", new[] { "", "a" })]
	[TestCase("a'b", new[] { "a", "b" })]
	[TestCase(@"""a \""c\""""", new[] { @"a ""c""" })]
	[TestCase(@"""\\""", new[] { @"\" })]
	[TestCase(@"\", new[] { @"\" })]
	[TestCase("  ", new string[] { })]
	[TestCase("a  b", new[] { "a", "b" })]
	[TestCase(@"'a""b", new[] { @"a""b" })]
	[TestCase(@"'a \''", new[] { @"a '" })]
	[TestCase("'b ", new[] { "b " })]
	[TestCase("'b'a", new[] { "b", "a" })]
	public static void RunTests(string input, string[] expectedOutput)
	{
		Test(input, expectedOutput);
	}
}

public class FieldsParserTask
{
	public static List<Token> ParseLine(string line)
	{
		var tokens = new List<Token>();
		var i = 0;
		while (i < line.Length)
		{
			if (line[i] == ' ')
			{
				i++;
				continue;
			}
			else
			{
				var flag = line[i] != '\'' && line[i] != '"';
				var t = flag ? ReadField(line, i) : ReadQuotedField(line, i);
				tokens.Add(t);
				i = t.GetIndexNextToToken();
			}
		}
		return tokens;
	}

	private static Token ReadField(string line, int startIndex)
	{
		var substring = new string("");
		for (int i = startIndex; i < line.Length; i++)
		{
			if (line[i] == ' ' || line[i] == '\'' || line[i] == '"')
			{
				return new Token(substring, startIndex, i - startIndex);
			}
			else
			{
				substring += line[i];
			}
		}
		return new Token(line.Substring(startIndex, line.Length - startIndex), startIndex, line.Length - startIndex);
	}

	public static Token ReadQuotedField(string line, int startIndex)
	{
		return QuotedFieldTask.ReadQuotedField(line, startIndex);
	}
}