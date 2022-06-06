<template>
    <div>

        <div class="modal fade" id="exampleModalToggle" aria-hidden="true" aria-labelledby="exampleModalToggleLabel"
            tabindex="-1">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-body mt-5" style="align-self: center;">
                        <svg width="100px" height="100px" viewBox="0 0 48 48" version="1"
                            xmlns="http://www.w3.org/2000/svg" enable-background="new 0 0 48 48">
                            <circle fill="#4CAF50" cx="24" cy="24" r="21" />
                            <polygon fill="#FFFFFF" points="34.6,14.6 21,28.2 15.4,22.6 12.6,25.4 21,33.8 37.4,17.4" />
                        </svg>
                    </div>
                    <h4 class="text mt-3 mb-4" style="align-self: center;">
                        Pedido finalizado com sucesso!
                    </h4>
                    <div class="modal-footer" style="align-self: center;">
                        <button class="btn btn-primary" style="background-color: #340E80; border-color: #340E80;"
                            data-bs-target="#exampleModalToggle2" data-bs-toggle="modal"
                            data-bs-dismiss="modal">OK</button>
                    </div>
                </div>
            </div>
        </div>
        <a class="btn btn-primary" data-bs-toggle="modal" href="#exampleModalToggle" role="button">Open first modal</a>
    </div>
</template>