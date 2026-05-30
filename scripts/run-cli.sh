#!/usr/bin/env bash
# Launch microCMDB.CLI for interactive run/debug, then close this Terminal
# window when the CLI exits. Intended to be run via Terminal.app's `do script`.
#
# Usage: run-cli.sh [host|docker]   (default: host)
#   host   - dotnet run on the macOS host (net6 target, rolls forward to net8/9)
#   docker - interactive run inside the microcmdb-cli container (native net6)
set -uo pipefail

MODE="${1:-host}"

# Resolve repo root from this script's location (scripts/ -> repo root).
ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
cd "$ROOT"

# Remember this window's tty so we can close exactly this window afterwards,
# regardless of which window is frontmost when the CLI exits.
THIS_TTY="$(tty)"

case "$MODE" in
  docker)
    docker run -it --rm microcmdb-cli dotnet microCMDB.CLI.dll
    ;;
  host)
    dotnet run --project microCMDB.CLI
    ;;
  *)
    echo "Unknown mode '$MODE' (expected 'host' or 'docker')" >&2
    ;;
esac

# Close this window in a detached child so the shell can exit first. Once the
# login shell has exited, Terminal closes the window without a confirmation
# prompt (no extra processes are running in it).
(
  /usr/bin/osascript -e "
    tell application \"Terminal\"
      repeat with w in windows
        repeat with t in tabs of w
          if tty of t is \"$THIS_TTY\" then
            close w saving no
            return
          end if
        end repeat
      end repeat
    end tell" >/dev/null 2>&1
) &
disown
exit
