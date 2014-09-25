ASCII-EBCDIC-Converter
======================

aec.exe - A Simple ASCII/EBCDIC Convetor Utility

This utility can convert files TO/From ASCII and EBCDIC Encoding and do line breaks.

List of Parameters

    Source filename to be converted
    <add key="sourcefilename" value="source.txt" />
	
	  Output filename
    <add key="outputfilename" value="destination.txt" />
	
    Convert to ASCII or EBCDIC
    <add key="convertto" value="ascii" />

    CODEPAGE E
    <add key="codepage" value="IBM037" />

    If CRLF is needed; after how many bytes.
    <add key="crlf" value="true" />
    <add key="skipbytesforcrlf" value="3000" />


References

MSDN - How to convert between ASCII and EBCDIC character codes support.microsoft.com/kb/216399

ASCII / EBCDIC 	www.simotime.com/asc2ebc1.htm

EBCDIC http://en.wikipedia.org/wiki/EBCDIC
