document.addEventListener('DOMContentLoaded', function () {
    // GitHub API URL - fetch repos
    const githubApiUrl = 'https://api.github.com/users/janymuong/repos';

    const xhr = new XMLHttpRequest();
    xhr.open('GET', githubApiUrl, true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState === 4 && xhr.status === 200) {
            const data = JSON.parse(xhr.responseText);
            const numProjectsToDisplay = 5;

            for (let i = 0; i < numProjectsToDisplay && i < data.length; i++) {
                const repo = data[i];
                let projectCard = '<div class="project-card">';
                projectCard += '<h3>' + repo.name + '</h3>';
                projectCard += '<img src="./img_icons/github-dark.svg" alt="GitHub Icon">';
                projectCard += '<p>' + repo.description + '</p>';
                projectCard += '<a href="' + repo.html_url + '" target="_blank">';
                projectCard += ' [view-source]</a>';
                projectCard += '</div>';

                document.getElementById('projects-container').innerHTML += projectCard;
            }
        } else if (xhr.readyState === 4) {
            console.error('Error fetching GitHub repos - We cry :(', xhr.status);
        }
    };
    xhr.send();
});