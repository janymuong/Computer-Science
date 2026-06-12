#!/usr/bin/env python

import numpy as np

# ── STEP 1: INITIALISE WEIGHTS ──────────────────────────
# Small random weights so all neurons learn differently
# If weights are all equal, all neurons learn the same thing

W1 = np.random.randn(2, 2) * 0.1   # 2 hidden × 2 inputs
b1 = np.zeros((2, 1))              # bias for hidden layer
W2 = np.random.randn(1, 2) * 0.1   # 1 output × 2 hidden
b2 = np.zeros((1, 1))              # bias for output layer

# ── ACTIVATION FUNCTION ──────────────────────────────────
# Sigmoid squashes any number into (0, 1)
# Derivative = y*(1-y)  — used in backprop

def sigmoid(z):
    return 1 / (1 + np.exp(-z))

# ── TRAINING DATA (XOR) ──────────────────────────────────
X = np.array([[0,0],[0,1],[1,0],[1,1]]).T  # shape (2, 4)
Y = np.array([[0, 1, 1, 0]])               # shape (1, 4)

# ── STEP 2: FORWARD PASS ─────────────────────────────────
# Hidden layer: Z1 = W1·X + b1,  A1 = sigmoid(Z1)
# Output layer: Z2 = W2·A1 + b2, A2 = sigmoid(Z2)

Z1 = W1 @ X + b1    # net input to hidden neurons
A1 = sigmoid(Z1)    # hidden layer output
Z2 = W2 @ A1 + b2   # net input to output neuron
A2 = sigmoid(Z2)    # prediction ŷ

# ── STEP 3: COMPUTE LOSS (MSE) ───────────────────────────
loss = np.mean((Y - A2) ** 2)

# ── STEP 4: BACKWARD PASS ────────────────────────────────
# Output delta: how wrong × how sensitive
# δ² = (ŷ - t) × sigmoid'(Z2)  where sigmoid'= A2*(1-A2)

dZ2 = (A2 - Y) * (A2 * (1 - A2))   # output delta
dW2 = dZ2 @ A1.T                    # gradient for W2
db2 = np.sum(dZ2, keepdims=True)    # gradient for b2

# Hidden delta: backpropagate output delta through W2
# δ¹ = W2ᵀ·δ² × sigmoid'(Z1)

dZ1 = (W2.T @ dZ2) * (A1 * (1 - A1))  # hidden delta
dW1 = dZ1 @ X.T                        # gradient for W1
db1 = np.sum(dZ1, keepdims=True)       # gradient for b1

# ── STEP 5: UPDATE WEIGHTS ───────────────────────────────
# Move each weight slightly against its gradient
# w = w - η × gradient  (η = learning rate)

eta = 0.5
W2 -= eta * dW2
b2 -= eta * db2
W1 -= eta * dW1
b1 -= eta * db1
