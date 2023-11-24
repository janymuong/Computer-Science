// ICS 2203 - Internet Apllication Programming;
// LIST assignment;

/*
GROUP MEMBERS;
  SCT211-0848/2018 - Jany Muong;
  SCT211-0057/2022 - Natasha Wangui Ndung'u;
  Kevin
  Jeff
*/
document.addEventListener('DOMContentLoaded', () => {
  const submit = document.getElementById('submit');
  const newTask = document.getElementById('task');

  submit.disabled = true;

  newTask.addEventListener('input', () => {
    submit.disabled = !newTask.value.trim();
  });

  document.querySelector('form').addEventListener('submit', (e) => {
    const taskIn = newTask.value.trim();

    const taskEL = document.createElement('li');
    taskEL.textContent = taskIn;

    // appendChild - create element for UL;
    document.getElementById('tasks').appendChild(taskEL);

    newTask.value = '';

    // inhibit default form submission
    e.preventDefault();
  });

  return false;
});
