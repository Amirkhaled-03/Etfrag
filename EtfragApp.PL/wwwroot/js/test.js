
document.addEventListener('DOMContentLoaded', function () {
    const episodeInput = document.querySelector('.episodies__num');
    const episodesContainer = document.getElementById('episodesContainer');

    episodeInput.addEventListener('input', function () {
        const numberOfEpisodes = parseInt(this.value) || 0;
        updateEpisodeFields(numberOfEpisodes);
    });

    function updateEpisodeFields(numberOfEpisodes) {
        episodesContainer.innerHTML = ''; // Clear existing content

        for (let i = 1; i <= numberOfEpisodes; i++) {
            const episodeDiv = document.createElement('div');
            episodeDiv.classList.add('col-12');
            episodeDiv.innerHTML = `
                    <div class="sign__episode">
                                        <div class="row">
                                            <div class="col-12">
                                                <span class="sign__episode-title text-white">Episode ${i}</span>
                                            </div>

                                            <div class="col-12 col-lg-8">
                                                <div class="form__video">
                                                    <label id="E${i}" for="form__video-upload${i}">Upload episode ${i}</label>
                                                    <input data-name="#E${i}" asp-for="@Model.Episodes" id="form__video-upload${i}" class="form__video-upload" type="file">
                                                    <span class="text-danger"></span>
                                                </div>
                                            </div>

                                            <div class="col-12 col-lg-4">
                                                <div class="form__group">
                                                    <input type="text" class="form__input" placeholder="Duration">
                                                </div>
                                            </div>


                                        </div>
                                    </div>
                `;

            episodesContainer.appendChild(episodeDiv);
        }
    }

    // Initialize with the default number of episodes
    updateEpisodeFields(parseInt(episodeInput.value) || 0);
});

