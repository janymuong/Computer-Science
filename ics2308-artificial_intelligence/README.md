# `diagnosys`

###  query basic facts
*(each entity has 2+ properties.)*  - is like props in react
```prolog
% get all patients with allergies  
?- patient(ID, Name, _, _, _, _, _, Allergies), Allergies \= [].  
% expected: john doe (penicillin), alice johnson (aspirin), etc.  

% list all oncologists  
?- doctor(_, Name, 'Oncology', _, _).  
% expected: dr. patel  
```



### **query r|ships**  
```prolog
% who prescribed insulin therapy?  
?- prescribed(Patient, 'Insulin Therapy', _, _, _),  
   diagnosed_with(Patient, _, _, DoctorID),  
   doctor(DoctorID, Doctor, _, _, _).  
% expected: jane smith (dr. patel)  

% find drug interactions for beta blockers  
?- drug_interaction('Beta Blockers', Drug2, Severity).  
% expected: insulin (moderate), inhaler (low)  
```

### **derived knowledge**  
```prolog
% who needs a follow-up? (Diagnosed >6 months ago)  
?- needs_follow_up(Patient).  
% expected: John Doe, Jane Smith  

% check for dangerous prescriptions  
?- dangerous_prescription(3).  
% expected: WARNING: 3 may have dangerous interaction/allergy with aspirin  
```

### **complex queries**  
```prolog
% find chronic patients with senior doctors  
?- chronic_patient(Patient),  
   diagnosed_with(Patient, _, _, DoctorID),  
   senior_doctor(Doctor).  
% expected: john doe (dr. williams), jane smith (dr. patel)  

% list today's appointments (mock date: 2023-04-15)  
?- todays_appointments(Doctor, Patient, Time).  
% expected: Dr. Williams, John Doe, 10:00  
```

### contagious, you
```prolog
% contagious disease alerts  
?- contagious_alert(Patient).  
% expected: Robert Brown (Influenza), Sarah Lee (COVID-19)  

% cost-effective treatments (SuccessRate > 0.7, Cost < $100)  
?- treatment(Name, _, Success, Cost), Success > 0.7, Cost < 100.  
% expected: Beta Blockers, Inhaler  
```

---

`prolog`

```prolog
 
?- [diagnosys].  
 
```

1. queries syntax (e.g., `dangerous_prescription(3)` for allergy warning).  
2. key features:  
   - drug interaction alerts (AI-like).  
   - chronic disease tracking.  
   - appointment scheduling.  
3.  extensions:  
   - add lab results (`lab_test(Patient, Test, Value)`).  
   - symptoms checker  
