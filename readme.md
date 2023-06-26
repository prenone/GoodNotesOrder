# GoodNotesOrder

I use the following naming convention for the notes I take:
"`{course} Appunti {dd-MM[-YY]}.pdf`".

GoodNotes uses alphabetical ordering and thus I get orderings like this which are not ideal:

- FIS/01 Appunti 01-01
- FIS/01 Appunti 02-01
- FIS/01 Appunti 10-02
- FIS/01 Appunti 27-01

This scripts reorganizes the files in a new folder so that they are sorted correctly like this

- 000-FIS/01 Appunti 01-01
- 001-FIS/01 Appunti 02-01
- 002-FIS/01 Appunti 27-01
- 003-FIS/01 Appunti 10-02

## Usage

Execute the following line

```bash
dotnet run /path/to/notes
```

Then a folder named `ordered` will be created.

## Caveats

- I have not used C# in quite a few years and could not remember how to work with paths a cross-platformy way, thus this code only works on systems that use '/' as separators in path.

- Many exceptions are to be *expected*.