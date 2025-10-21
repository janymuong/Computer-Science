**MIME** is short for **Multipurpose Internet Mail Extensions**


### What MIME Actually Is:
MIME is a standard that extends the format of email messages to support:
- **Text** in character sets other than ASCII
- **Attachments** (audio, video, images, application files)
- **Message bodies** with multiple parts
- **Non-ASCII** header information

### How Jupyter Uses MIME Types
In Jupyter notebooks, MIME types determine **how to display cell outputs**:

```json
"data": {
  "text/plain": "This appears in plain text",
  "text/html": "<b>This appears as bold HTML</b>",
  "image/png": "base64encodedimagedata...", 
  "application/json": "{\"data\": \"structured\"}",
  "text/markdown": "**Markdown rendering**",
  "text/latex": "$E = mc^2$"
}
```

The frontend looks at all these MIME types and picks the **richest available format** that it can display.

---

## Jupyter Notebook Checkpoints: How They Work

### What Are Checkpoints?
checkpoints are **automatic backups** of your notebook that get created periodically and when you manually save.

### How They Work

#### 1. **Location**
- checkpoints are stored in a **hidden folder** in the same directory as your notebook:
```
my_notebook.ipynb
.checkpoints/
├── my_notebook.ipynb  # <-- checkpoint file
```

#### 2. **Creation Triggers**
- **Manual save** (`Ctrl+S`)
- **Automatic periodic saves** (every 30-120 seconds, depending on configuration)
- **Before certain operations** (like restarting kernel)

#### 3. **File Structure**
Checkpoint files are **identical in format** to regular notebook files - they're just JSON copies:
```json
{
  "cells": [...],
  "metadata": {...},
  "nbformat": 4,
  "nbformat_minor": 5
}
```

#### 4. **Restoration Process**
When you use **"File → Revert to Checkpoint"**:
- Jupyter copies the checkpoint file over your current notebook file
- Reloads the notebook from disk
- You lose any changes made since the checkpoint

### Configuration
You can configure checkpoints in Jupyter config:
```python
# In jupyter_notebook_config.py
c.NotebookApp.checkpoint_dir = '/path/to/checkpoints'
c.ContentsManager.checkpoint_dir = '/path/to/checkpoints'
```

### Key Points About Checkpoints

- **Only ONE checkpoint is kept** per notebook (it gets overwritten)
- **Not version control** - they don't keep history, just the last known good state
- **Local only** - checkpoints don't get synced to JupyterHub or cloud services
- **Automatic cleanup** - checkpoints are deleted when you close the notebook properly

### Manual Checkpoints
> you can also create manual checkpoints via the API:
```python
# In a notebook cell
import notebook
notebook.checkpoints.create_checkpoint(contents_manager, notebook_path)
```