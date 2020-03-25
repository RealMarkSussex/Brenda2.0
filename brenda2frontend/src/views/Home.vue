<template>
  <div class="home">
    <SkillsTable></SkillsTable>
    <SkillsForm></SkillsForm>
  </div>
</template>

<script>
// @ is an alias to /src
import SkillsTable from '@/components/SkillsTable.vue'
import SkillsForm from '@/components/SkillsForm.vue'

export default {
  name: 'Home',
  components: {
    SkillsTable,
    SkillsForm
  }
}
</script>
