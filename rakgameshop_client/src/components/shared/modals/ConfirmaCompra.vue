<template>
    <div>

        <div class="modal fade" id="exampleModalToggle" aria-hidden="true" aria-labelledby="exampleModalToggleLabel"
            tabindex="-1">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-body mt-5" style="align-self: center;">
                        <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" fill="currentColor"
                            class="bi bi-info-circle" viewBox="0 0 16 16">
                            <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14zm0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16z" />
                            <path
                                d="m8.93 6.588-2.29.287-.082.38.45.083c.294.07.352.176.288.469l-.738 3.468c-.194.897.105 1.319.808 1.319.545 0 1.178-.252 1.465-.598l.088-.416c-.2.176-.492.246-.686.246-.275 0-.375-.193-.304-.533L8.93 6.588zM9 4.5a1 1 0 1 1-2 0 1 1 0 0 1 2 0z" />
                        </svg>
                    </div>
                    <h4 class="text mt-3 mb-4" style="align-self: center;">
                        Deseja confirmar a compra?
                    </h4>
                    <div class="modal-footer" style="align-self: center;">
                        <button class="btn btn-primary" style="background-color: #340E80; border-color: #340E80;"
                            data-bs-target="#exampleModalToggle2" data-bs-toggle="modal"
                            data-bs-dismiss="modal">CONFIRMAR</button>
                        <button class="btn btn-primary"
                            style="color: #340E80; background-color: white; border-color: #340E80;"
                            data-bs-target="#exampleModalToggle2" data-bs-toggle="modal"
                            data-bs-dismiss="modal">CANCELAR</button>
                    </div>
                </div>
            </div>
        </div>
        <a class="btn btn-primary" data-bs-toggle="modal" href="#exampleModalToggle" role="button">Open first modal</a>
    </div>
</template>