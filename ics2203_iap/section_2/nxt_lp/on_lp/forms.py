# on_lp/forms.py
from django import forms
from .models import UserSubmission

class UserSubmissionForm(forms.ModelForm):
    class Meta:
        model = UserSubmission
        fields = ['full_name', 'email', 'phone_number', 'message']
