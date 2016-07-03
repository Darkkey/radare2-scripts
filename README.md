## Collection of scripts for radare2 framework

### fsharp/avrports.exe
Script for commenting pure AVR binary firmware with I/O ports description. Runs from radare2 command line.

Installation:
```
paket install
make
```

Usage: 
```
[0x00000000]> #!pipe mono ./avrports.exe <path to avr assembler (avra) platform inc file> [start_address end_address]`
```

Examples:
```
[0x00000000]> #!pipe mono ./avrports.exe /usr/local/Cellar/avra/1.3.0/share/avra/m128def.inc
[0x00000000]> #!pipe mono ./avrports.exe /usr/local/Cellar/avra/1.3.0/share/avra/m128def.inc 0x00 0xae
```