# on_lp/views.py
from django.shortcuts import render
from .forms import UserSubmissionForm

def home(request):
    form = UserSubmissionForm()

    if request.method == 'POST':
        form = UserSubmissionForm(request.POST)
        if form.is_valid():
            form.save()

    return render(request, 'on_lp/home.html', {'form': form})
