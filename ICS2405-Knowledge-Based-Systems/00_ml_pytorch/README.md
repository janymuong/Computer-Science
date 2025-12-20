# ML in PyTorch
> (machine) learning systems


---
### attention is all you need:

# Vision Transformer (ViT) for CIFAR-10
A small pracrice exercise following this from geeksforgeeks - i.e. training a ViT on the CIFAR-10 dataset. "Attention Is All You Need" for image recognition.

## salient:
a vit treats an image as a sequence of patches and uses a transformer encoder to model relationships between them.

## core deps:
*   **PyTorch** & **Torchvision**: for model definition, training, and data loading.
*   **`timm` Library**: A popular PyTorch image models library that provides a pre-trained Vision Transformer.
*   Standard libraries: `torch.nn`, `torch.optim`.

---

1.  **Data Preparation**:
    *   Load CIFAR-10 (32x32 images, 10 classes).
    *   **Crucial Step**: Resize images to 224x224, as standard pre-trained ViT models expect this input size.
    *   Apply normalization (using ImageNet stats for pre-trained models).

2.  **Model Definition**:
    *   Use `timm.create_model('vit_base_patch16_224', pretrained=True, num_classes=10)`.
    *   this loads a ViT model pre-trained on ImageNet and adjusts its final head for our 10 classes.

3.  **Training Loop**:
    *   **Forward Pass**: images are split into 16x16 patches, linearly embedded, and passed through the Transformer encoder.
    *   **Loss & Optimization**: Use `CrossEntropyLoss` and the `Adam` optimizer.
    *   **Key Operations**: Remember to zero gradients (`optimizer.zero_grad()`), compute loss, perform backpropagation (`loss.backward()`), and update weights (`optimizer.step()`).

4.  **Evaluation**:
    *   set the model to `eval()` mode.
    *   use `with torch.no_grad():` to disable gradient calculation for faster inference.
    *   compute accuracy by comparing predictions (`torch.max(outputs.data, 1)`) to true labels.

## Considerations for CIFAR-10
*   **Image Size**: CIFAR-10 images are small (32x32). Resizing them to 224x224 for a standard ViT is necessary but introduces artifacts. For a purer experiment, consider a ViT variant designed for smaller images (e.g., patch size of 4 or 8).
*   **Computational Cost**: The `vit_base_patch16_224` model is large. Ensure you have adequate GPU memory.
*   **Overfitting**: ViTs can overfit on smaller datasets. we can consider strong augmentation (RandAugment, CutMix) and regularization (dropout, weight decay) for better results.
