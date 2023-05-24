async function fetchAndProcessData() {
  try {
    const response = await fetch('http://localhost:6969/daten');
    const data = await response.json();

    data.sort((a, b) => parseFloat(a._gesamtZeit) - parseFloat(b._gesamtZeit));

    const rankingList = document.getElementById('ranking-list');
    const header = document.createElement('li');
    header.classList.add('header');
    header.innerHTML = `
      <span class="position">Position</span>
      <span class="name"></span>
      <span class="time">Gesamtzeit</span>
    `;
    rankingList.appendChild(header);

    let currentPosition = 1;
    let previousTime = null;

    data.forEach((team, index) => {
      const { _teamName, _gesamtZeit } = team;

      const listItem = document.createElement('li');

      if (_gesamtZeit !== previousTime) {
        currentPosition = index + 1;
        previousTime = _gesamtZeit;
      }

      const teamName = document.createElement('span');
      teamName.classList.add('name', 'teamname');
      teamName.setAttribute('data-text', _teamName);
      teamName.textContent = _teamName;

      listItem.innerHTML = `
        <span class="position ${getPositionClass(currentPosition)}">${getPositionText(currentPosition)}</span>
        ${currentPosition === 1 ? '<img class="trophy" src="trophy.png" alt="Trophy">' : ''}
        ${teamName.outerHTML}
        <span class="time">${parseFloat(_gesamtZeit).toFixed(2)} minutes</span>
      `;

      rankingList.appendChild(listItem);
    });
  } catch (error) {
    console.error('Error:', error);
  }
}

function getPositionText(position) {
  if (position === 1) {
    return '1st';
  } else if (position === 2) {
    return '2nd';
  } else if (position === 3) {
    return '3rd';
  } else {
    return `${position}th`;
  }
}

function getPositionClass(position) {
  if (position === 1) {
    return 'gold';
  } else if (position === 2) {
    return 'silver';
  } else if (position === 3) {
    return 'bronze';
  } else {
    return 'normal';
  }
}

fetchAndProcessData()
  .then(() => console.log('Data fetched and processed successfully'))
  .catch(error => console.error('Error:', error));

  const rankingLogo = document.querySelector('.ranking-logo');
rankingLogo.style.backgroundImage = 'url(Vector.svg)';