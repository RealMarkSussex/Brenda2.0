<template>
  <div>
      //render a skill component and a level number and skill Level Description
  </div>
</template>

<script>
export default {
    data() {
        return {
            level: undefined,
            skillLevel: undefined,
            skill: undefined
        }
    },
    props: {
        userSkill: {
            type: Object,
            default: {} 
        },
    },
    created() {
        //populate skillLevel and maybe make a level component which takes level id and just renders that number
    }
}
</script>

<style>

</style>