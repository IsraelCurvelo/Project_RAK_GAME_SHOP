<script>
    export default{
        methods: {
            setFlagPix(){
                this.$parent.setFlagPix();
            }
        }
    }
</script>

<template>
    <div>
        <div class="row">
            <div class="modal fade" id="modalPix" aria-hidden="true" tabindex="-1">
                <div class="modal-dialog modal-dialog-centered">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalToggleLabel">PIX</h5>
                            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                        </div>
                        <div class="modal-body" style="align-self: center; text-align: center;">
                            <img src="../../../assets/qrcode.png" style="width: 300px;" />
                            <form>
                                <textarea style="font-size: 8px" type="text" class="form-control-plaintext" disabled readonly>
                                    00020126360014BR.GOV.BCB.PIX0105TESTE0205TESTE52040000530398654040.005802BR5905TESTE6015Mogi das Cru zes610908773-60062090505TESTE63049626
                                </textarea> 
                            </form>
                        </div>
                        <div class="modal-footer" style="align-self: center;">
                            <button class="btn btn-primary" style="background-color: #340E80; border-color: #340E80;"
                                data-bs-target="#modalPix" data-bs-toggle="modal" data-bs-dismiss="modal">Copiar
                                código</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <button @click="setFlagPix()" class="accordion-button collapsed" type="button" style="color: white; background-color: #414040;"
            data-bs-toggle="modal" href="#modalPix">
            <img src="../../../assets/pix-banco-central.svg" style="width: 30px;" />
            &nbsp; PIX
        </button>
    </div>
</template>