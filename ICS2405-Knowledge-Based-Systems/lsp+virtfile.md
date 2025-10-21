# LSP

`.virtual_documents` is a **language server protocol (LSP) feature**. this is used in jupyterlab, probably not a core Jupyter notebook concept.

INNFO:
```sh
┌─[:)@arch] - [~] - [Tue Oct 21, 05:58]
└─[$] <> pacman -Qs lsp
local/jupyter-lsp 2.3.0-1
    Multi-Language Server WebSocket proxy for Jupyter Notebook/Lab server.
local/python-lsp-black 2.0.0-4
    python-lsp-server plugin that adds support to black autoformatter, forked from pyls-black
local/python-lsp-jsonrpc 1.1.2-5
    Fork of the python-jsonrpc-server project, maintained by the Spyder IDE team and the community
local/python-lsp-server 1.12.2-1
    Fork of the python-language-server project, maintained by the Spyder IDE team and the community
┌─[:)@arch] - [~] - [Tue Oct 21, 05:58]
└─[$] <> 
```

## WHAT `.virtual_documents` IS:

this is a **virtual file system** that lsp servers use to understand code that exists **only in memory** within notebook cells.

## the PROBLEM it SOLVES:

traditionally, lsp servers expect to work with **actual files on disk** but in jupyter:

- code lives in **cells in memory**
- there's no permanent `.py` file for each cell
- the execution context is **ephemeral**
- code execution order matters

## how `.virtual_documents` works

### `w/o` virtual files:
```python
# cell 1 - LSP can't see this for cell 2 analysis
def my_function():
    return "hello"

# cell 2 - LSP gets confused about my_function
result = my_function()  # LSP: "undefined function"
```

### `w/`:
> jupyterlab creates a virtual file structure:

```python
.virtual_documents/
├── notebook.ipynb
    ├── cell-1.py  #: def my_function(): ...
    ├── cell-2.py  #: result = my_function()
    └── context.py #: all executed cells in order
```

## technical implementation

jupyterlab's lsp extension creates **virtual files** that represent:

1. **individual cells** as separate virtual files
2. **execution context** - all previously run cells combined
3. **Ttmporary files** for analysis purposes

### Virtual Structure:
```
.virtual_documents/
└── notebook-A.ipynb/
    ├── cell-1.py    # first executed cell
    ├── cell-2.py    # second executed cell  
    ├── cell-3.py    # third executed cell
    └── __all__.py   # all cells concatenated in execution order
```

## what you "see" - in practice

### better code intelligence:
- **auto-completion** that understands variables from previous cells
- **go to definition** works across cells
- **error checking** that considers execution context
- **refactoring** that understands the notebook's state

### configuration:
> INFO: in jupyterlab's advanced settings editor:  

```json
{
  "@jupyterlab/lsp-extension:plugin": {
    "virtualDocuments": {
      "enabled": true,
      "context": true
    }
  }
}
```

## WHY this MATTERS:

**before `.virtual_documents`:**
- LSP only saw the current cell
- no understanding of variables/functions from previous cells
- limited code intelligence

**after `.virtual_documents`:**
- LSP sees the **execution context**
- full understanding of your notebook's state
- IDE-like features

## limits

- **performance**: creating virtual files has overhead
- **complexity**: more moving parts can mean more bugs
- **memory**: virtual documents consume RAM
- **temporary**: files disappear when notebook closes
