Get or set Environment variables in Windows Console.
> 1. Download [exe file](https://raw.githubusercontent.com/winp/extra-bel/master/ecd.cmd).
> 2. Copy to `C:\Program_Files\Scripts`.
> 3. Add `C:\Program_Files\Scripts` to `PATH` environment variable.


```batch
> oenv [-m|--machine] [get|set|delete|has|add|remove] <variable> [<value>]

:: [] -> optional argument
:: <> -> argument value
```

```batch
:: list user environment variables
> oenv

:: list machine environment variables
> oenv --machine

:: get user environment variable "public_key"
> oenv get public_key

:: get machine environment variable "path"
> oenv -m get path

:: set user environment variable "public_key"
> oenv set public_key fe84c9fd861baabfcfb0336bf16490f2

:: set machine environment variable "machine_sig"
> oenv -m set machine_sig 253f3400dfa524c0cd89c5c5eb1e03ee

:: delete user environment variable "private_key"
> oenv delete private_key

:: delete machine environment variable "machine_sig"
> oenv -m delete machine_sig

:: check if user environment variable "path" has "play-unreal3.exe" path
> oenv has path "C:\Program_Files\Unreal Tournament\Unreal Tournament 3"

:: check if machine environment variable "path" has "Hacker Evolution Untold.exe path" path
> oenv -m has path "C:\Program Files (x86)\Hacker Evolution Untold"

:: add "PA.exe" path to user environment variable "path"
> oenv add path "C:\Program_Files\Planetary Annihilation"

:: add "watch_dogs.exe" path to machine environment variable "path"
> oenv -m add path "C:\Program Files (x86)\R.G. Mechanics\Watch Dogs\bin"

:: remove "dota_2.exe" path from user environment variable "path"
> oenv remove path "C:\Program_Files\Dota 2"

:: remove "SDK Manager.exe" path from machine environment variable "path"
> oenv -m remove path "C:\Program_Files\Android\SDK"
```
