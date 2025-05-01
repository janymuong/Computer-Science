% ICS 2308 Artificial Intelligence - Dignosys Knowledge Base in Prolog
% A KB for medical dignosis, patients, docs etc in one place


% Group 7
% SCT211-0848/2018 - Jany Muong
% SCT211-0079/2022 - Joram Kireki 
% SCT211-0504/2021 - Gatmach Yuol Nyuon 
% SCT211-0003/2022 - Josphat Waweru Thumi 
% SCT211-0535/2022 - Akech Atem
% SCT211-0070/2022 - Vincent Ochieng



% ----------------------------
% 1. BASIC FACTS (Entities)
% ----------------------------


% PATIENTS (ID, Name, Age, Gender, BloodType, Weight(kg), Height(cm), Allergies)
patient(1, 'John Doe', 45, 'Male', 'A+', 85, 175, ['Penicillin']).
patient(2, 'Jane Smith', 32, 'Female', 'O-', 62, 165, []).
patient(3, 'Alice Johnson', 28, 'Female', 'B+', 58, 170, ['Aspirin']).
patient(4, 'Robert Brown', 60, 'Male', 'AB+', 90, 180, ['Sulfa']).
patient(5, 'Emily Davis', 50, 'Female', 'A-', 70, 168, ['Ibuprofen']).
patient(6, 'Michael Wilson', 35, 'Male', 'B-', 78, 172, []).
patient(7, 'Sarah Lee', 29, 'Female', 'O+', 55, 160, ['Peanuts']).

% DOCTORS (ID, Name, Specialization, YearsExperience, Hospital)
doctor(101, 'Dr. Williams', 'Cardiology', 15, 'City General').
doctor(102, 'Dr. Lee', 'Neurology', 10, 'City General').
doctor(103, 'Dr. Patel', 'Oncology', 20, 'Memorial Hospital').
doctor(104, 'Dr. Garcia', 'General', 5, 'Community Clinic').
doctor(105, 'Dr. Kim', 'Pediatrics', 12, 'Children’s Hospital').

% DISEASES (Name, Category, Severity, Contagious)
disease('Hypertension', 'Cardiovascular', 'Chronic', false).
disease('Diabetes Type 2', 'Metabolic', 'Chronic', false).
disease('Migraine', 'Neurological', 'Acute', false).
disease('Influenza', 'Infectious', 'Acute', true).
disease('COVID-19', 'Infectious', 'Variable', true).
disease('Asthma', 'Respiratory', 'Chronic', false).

% TREATMENTS (Name, Type, SuccessRate, Cost)
treatment('Beta Blockers', 'Medication', 0.85, 50).
treatment('Insulin Therapy', 'Medication', 0.75, 200).
treatment('Physical Therapy', 'Therapy', 0.60, 80).
treatment('Antiviral Meds', 'Medication', 0.70, 120).
treatment('Inhaler', 'Medication', 0.90, 30).

% ----------------------------
% 2. RELATIONSHIPS
% ----------------------------

% DIAGNOSED_WITH (PatientID, Disease, Date, DoctorID)
diagnosed_with(1, 'Hypertension', '2022-01-15', 101).
diagnosed_with(2, 'Diabetes Type 2', '2021-11-03', 103).
diagnosed_with(3, 'Migraine', '2023-02-20', 102).
diagnosed_with(4, 'Influenza', '2023-03-10', 104).
diagnosed_with(5, 'Hypertension', '2022-05-22', 101).
diagnosed_with(6, 'Asthma', '2023-01-10', 105).
diagnosed_with(7, 'COVID-19', '2023-03-01', 104).

% PRESCRIBED (PatientID, Treatment, Dosage, StartDate, EndDate)
prescribed(1, 'Beta Blockers', '50mg/day', '2022-01-20', '2023-01-20').
prescribed(2, 'Insulin Therapy', '10 units/day', '2021-11-05', 'ongoing').
prescribed(3, 'Physical Therapy', '2 sessions/week', '2023-02-25', '2023-05-25').
prescribed(4, 'Antiviral Meds', '75mg/day', '2023-03-12', '2023-03-26').
prescribed(6, 'Inhaler', '2 puffs/day', '2023-01-15', 'ongoing').

% APPOINTMENT (PatientID, DoctorID, DateTime, Purpose)
appointment(1, 101, '2023-04-15 10:00', 'Follow-up').
appointment(2, 103, '2023-04-16 14:30', 'Bloodwork').
appointment(3, 102, '2023-04-17 09:15', 'Neurological Exam').
appointment(6, 105, '2023-04-18 11:00', 'Asthma Checkup').

% DRUG_INTERACTION (Drug1, Drug2, Severity)
drug_interaction('Beta Blockers', 'Insulin', 'Moderate').
drug_interaction('Aspirin', 'Ibuprofen', 'Severe').
drug_interaction('Antiviral Meds', 'Alcohol', 'High').
drug_interaction('Inhaler', 'Beta Blockers', 'Low').

% ----------------------------
% 3. DERIVED RULES (Logic)
% ----------------------------

% RULE 1: Chronic patients
chronic_patient(Patient) :-  
    diagnosed_with(Patient, Disease, _, _),  
    disease(Disease, _, 'Chronic', _).  

% RULE 2: Senior doctors (10+ years)
senior_doctor(Doctor) :-  
    doctor(_, Doctor, _, Years, _),  
    Years >= 10.  

% RULE 3: Effective treatments (SuccessRate > 0.75)
effective_treatment(Treatment) :-  
    treatment(Treatment, _, Success, _),  
    Success > 0.75.  

% RULE 4: Obese patients (BMI > 30)
obese_patient(Patient) :-  
    patient(Patient, _, _, _, _, Weight, Height, _),  
    BMI is Weight / ((Height / 100) ** 2),  
    BMI > 30.  

% RULE 5: Contagious disease alert
contagious_alert(Patient) :-  
    diagnosed_with(Patient, Disease, _, _),  
    disease(Disease, _, _, true).  

% RULE 6: Drug interaction/allergy warning
dangerous_prescription(Patient) :-  
    prescribed(Patient, Drug1, _, _, _),  
    patient(Patient, _, _, _, _, _, _, Allergies),  
    ( member(Drug2, Allergies) ; drug_interaction(Drug1, Drug2, _) ),  
    format('WARNING: ~w may have dangerous interaction/allergy with ~w~n', [Patient, Drug2]).  

% RULE 7: Upcoming appointments (mock today: 2023-04-15)
todays_appointments(Doctor, Patient, Time) :-  
    appointment(Patient, DoctorID, DateTime, _),  
    sub_string(DateTime, 0, 10, _, '2023-04-15'),  
    doctor(DoctorID, Doctor, _, _, _),  
    sub_string(DateTime, 11, 5, _, Time).  

% RULE 8: Patients needing follow-up (diagnosed >6 months ago)
needs_follow_up(Patient) :-  
    diagnosed_with(Patient, _, Date, _),  
    sub_string(Date, 0, 4, _, Year),  
    sub_string(Date, 5, 2, _, Month),  
    sub_string(Date, 8, 2, _, Day),  
    atom_number(Year, Y), atom_number(Month, M), atom_number(Day, D),  
    get_time(Stamp), stamp_date_time(Stamp, DateTime, local),  
    date_time_value(year, DateTime, CurrentYear),  
    date_time_value(month, DateTime, CurrentMonth),  
    date_time_value(day, DateTime, CurrentDay),  
    ( (CurrentYear - Y > 0) ;  
      (CurrentYear == Y, CurrentMonth - M > 6) ;  
      (CurrentYear == Y, CurrentMonth - M == 6, CurrentDay >= D) ).  