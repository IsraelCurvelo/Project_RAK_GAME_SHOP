<script>
    export default{
        methods: {
            setFlagBoleto(){
                this.$parent.setFlagBoleto();
            }
        }
    }
</script>

<template>
    <div>

        <div class="modal" id="modalBoleto" aria-hidden="true" tabindex="-1">
            <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalToggleLabel">Boleto</h5>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body" style="align-self: center;">
                        <img src="../../../assets/barcode.png" style="width: 300px; border-style: solid;" />
                    </div>
                    <div class="modal-footer" style="align-self: center;">
                        <button class="btn btn-primary" style="background-color: #340E80; border-color: #340E80;"
                            data-bs-target="#modalBoleto" data-bs-toggle="modal" data-bs-dismiss="modal">Gerar
                            Boleto</button>
                    </div>
                </div>
            </div>
        </div>
        <button @click="setFlagBoleto()" class="accordion-button collapsed" type="button" style="color: white; background-color: #414040;"
            data-bs-toggle="modal" href="#modalBoleto">
            <svg xmlns="http://www.w3.org/2000/svg" width="30" height="30" fill="currentColor" class="bi bi-upc"
                viewBox="2 0 15 15">
                <path
                    d="M3 4.5a.5.5 0 0 1 1 0v7a.5.5 0 0 1-1 0v-7zm2 0a.5.5 0 0 1 1 0v7a.5.5 0 0 1-1 0v-7zm2 0a.5.5 0 0 1 1 0v7a.5.5 0 0 1-1 0v-7zm2 0a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-.5.5h-1a.5.5 0 0 1-.5-.5v-7zm3 0a.5.5 0 0 1 1 0v7a.5.5 0 0 1-1 0v-7z" />
            </svg>
            &nbsp; Boleto
        </button>
    </div>
</template>