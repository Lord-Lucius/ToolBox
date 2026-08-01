#!/usr/bin/env bash
set -euo pipefail

# Détecte le RID selon l'architecture
case "$(uname -m)" in
    x86_64)  RID="linux-x64" ;;
    aarch64) RID="linux-arm64" ;;
    *) echo "Architecture non supportée: $(uname -m)" >&2; exit 1 ;;
esac

PROJECT="src/ToolBox.App"
OUTDIR="$HOME/.local/share/toolbox/bin"
BINDIR="$HOME/.local/bin"

echo "Publishing for $RID..."
dotnet publish "$PROJECT" \
    -c Release \
    -r "$RID" \
    --self-contained \
    -p:PublishSingleFile=true \
    -o "$OUTDIR"

mkdir -p "$BINDIR"
ln -sf "$OUTDIR/tbx" "$BINDIR/tbx"

echo "Installed: $BINDIR/tbx -> $OUTDIR/tbx"
