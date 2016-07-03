## Collection of scripts for radare2 framework

### EN
- `fsharp/avrports.exe` - script for commenting pure AVR binary firmware with I/O ports description
    Run from radare2 command line
    Usage: > #!pipe mono ./avrports.exe <path to avr assembler (avra) platform inc file> [start_address end_address]
    Examples:
        > #!pipe mono ./avrports.exe /usr/local/Cellar/avra/1.3.0/share/avra/m128def.inc
        > #!pipe mono ./avrports.exe /usr/local/Cellar/avra/1.3.0/share/avra/m128def.inc 0x00 0xae